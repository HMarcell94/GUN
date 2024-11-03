import express, { Router, Request, Response } from "express"
import { createInstitution, deleteInstitution, getInstitutions, updateInstitution } from "../services/InstitutionService";
import Validator from "./validator";

const router: Router = express.Router()
const rules = {
    "name": "required",
    "city": "required",
    "directorId": "required|number"
}

router.get("/", async (req: Request, res: Response) => {
    const result = await getInstitutions();

    return res.json(result)
})

router.post("/create", async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req, res);

    if (!validate) {
        await createInstitution(req, res);
    }
})

router.put("/update/:id", async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req, res);

    if (!validate) {
        await updateInstitution(req, res);
    }
})

router.delete("/delete/:id", async (req: Request, res: Response) => {
    await deleteInstitution(req, res);
})

export default router;