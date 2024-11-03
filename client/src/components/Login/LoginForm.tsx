'use client';
import { login } from "@/actions/loginForm";
import { useCookies } from "next-client-cookies";
import Notiflix from "notiflix";
import React from "react";
import { Form, Button } from "react-bootstrap"

export default function LoginForm() {
    const cookies = useCookies();

    async function onLogin(formData: FormData) {
        const res = await login(formData);
        
        if (!res.error) {
            cookies.set("user", JSON.stringify(res));
            Notiflix.Notify.success("Sikeres bejelentkezés!", () => {
                location.href = "/"
            }, {
                timeout: 2000
            })
        } else {
            let message = res.messages;
            if (Array.isArray(message)) {
                message = message[0]
            }
            console.log(message)
            Notiflix.Notify.failure(message as string)
        }
    }

    return (
        <form action={onLogin}>
            <Form.Group className="mb-3">
                <Form.Label>Email cím</Form.Label>
                <Form.Control 
                    type="email" 
                    name="email"
                />
            </Form.Group>
            <Form.Group className="mb-3">
                <Form.Label>Jelszó</Form.Label>
                <Form.Control 
                    type="password" 
                    name="password"
                />
            </Form.Group>
            <Form.Group>
                <Button type="submit" variant="primary">Bejelentkezés</Button>
            </Form.Group>
        </form>
    )
}