import express, { Router,Request,Response } from "express";
import { createGroup, deleteGroup, getGroups, updateGroup } from "../services/groupService";
import Validator from "./validator";

const router: Router = express.Router();
const rules = {
    "to": "required|dateTime",
    "from": "required|dateTime",
    "days": "required|number",
    "reason": "required",
    "typeId": "required|number",
    "employeeId": "required|number",
}

router.get("/",async (req: Request, res: Response) => {
    const result = await getGroups();
    return res.status(200).json(result);
})

router.post("/create",async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req,res)

    if (!validate) {
        await createGroup(req, res);
    }
})

router.put("/update/:id",async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req,res)

    if (!validate) {
        await updateGroup(req, res);
    }
})

router.delete("/delete/:id",async (req: Request, res: Response) => {
    await deleteGroup(req, res);
})

export default router;
