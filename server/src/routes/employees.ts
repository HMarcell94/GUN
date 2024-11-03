import express, { Router, Request, Response } from "express"
import Validator from "./validator";
import { createEmployee, deleteEmployee, getEmployees, login, updateEmployee } from "../services/employeeService";

const router: Router = express.Router()
const rules = {
    "firstName": "required",
    "lastName": "required",
    "email": "required",
    "password": "required",
    "phone": "required",
    "dayCount": "required|number",
}

router.get("/", async (req: Request, res: Response) => {
    const employees = await getEmployees();

    return res.status(200).json(employees)
})

router.post("/create", async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req,res)

    if (!validate) {
        await createEmployee(req, res)
    }
})

router.put("/update/:id", async (req: Request, res: Response) => {
    const validate = (new Validator(rules)).validate(req,res)

    if (!validate) {
        await updateEmployee(req, res)
    }
})

router.delete("/delete/:id", async (req: Request, res: Response) => {
    await deleteEmployee(req, res)
})

router.post("/login", async (req: Request, res: Response) => {
    const validate = (new Validator({
        email: "required",
        password: "required"
    })).validate(req,res)

    if (!validate) {
        await login(req, res);
    }
})

export default router;