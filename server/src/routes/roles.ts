import express, { Router, Request, Response } from "express";
import { checkRole, getRoles } from "../services/roleService";
import Validator from "./validator";

const router: Router = express.Router();

router.get("/", async (req: Request, res: Response) => {
    return res.json(await getRoles())
})

router.get("/check", async (req: Request, res: Response) => {
    const rules = {
        userId: "required",
        roleId: "required"
    }
    const valid = (new Validator(rules)).validate(req, res, "query");

    if (!valid) {
        const hasRole = await checkRole(
            parseInt(req.query.roleId as string),
            parseInt(req.query.userId as string)
        );
        return res.json(hasRole)
    }
})

export default router;