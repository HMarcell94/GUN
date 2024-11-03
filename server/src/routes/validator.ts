import { Request, Response } from "express";

export default class Validator {
    public rules: Record<string,string[]>;
    private messages: Record<string,string> = {
        "required": "A :field mező megadása kötelező!",
        "number": "A :field mező típusa szám kell, hogy legyen!",
        "dateTime": "A :field mező típusa értelmezhető dátum és idő kell hogy legyen! (YYYY-MM-dd HH:mm)"
    }

    constructor(
        rules: Record<string,string>
    ) {
        this.rules = {};
        Object.keys(rules).forEach((key) => {
            this.rules[key] = rules[key].split("|");
        })
    }

    private checkRule(fields: Record<string, any>, field: string, rule: string): boolean {
        switch (rule)
        {
            case "required":
                return fields[field] !== undefined;
                break;

            case "number":
                return typeof fields[field] === "number";
                break;

            case "dateTime":
                const regex = new RegExp(/\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])\s(0[1-9]|1\d|2[0-3]):([0-5]\d)/m);
                return regex.test(fields[field]);
                break;
        }
        return false;
    }

    public validate(request: Request, response: Response, place: "body"|"query"|"params" = "body") {
        const fields = Object.keys(this.rules);
        const result: Record<string, Record<string, boolean>> = {};
        let hasError = false;

        if (!request[place]) {
            return response.status(400).json({
                error: true,
                messages: [
                    "Üres adathalmaz!"
                ]
            })
        }

        fields.forEach(field => {
            result[field] = {};
            this.rules[field].forEach(rule => {
                result[field][rule] = this.checkRule(request[place], field, rule)
                if (!hasError && result[field][rule] === false) {
                    hasError = true;
                }
            })
        })
        
        if (hasError) {
            const messages: string[] = []
            Object.keys(result).forEach(field => {
                Object.keys(result[field]).forEach(rule => {
                    if (!result[field][rule]) {
                        messages.push(this.getMessage(rule,field))
                    }
                })
            })

            return response.status(400).json({
                error: true,
                messages: messages
            })
        }
        return false;
    }

    private getMessage(rule: string, field: string): string {
        return this.messages[rule].replace(":field", field)
    }
}