import { PrismaClient } from "@prisma/client";
import { IEmployee } from "../interfaces/employee";
import { Request, Response } from "express"
import bcrypt from "bcrypt";

const prisma = new PrismaClient();

export async function getEmployees() {
    const employees = await prisma.employee.findMany({
        include: {
            roles: {
                select: {
                    role: true
                }
            },
            dayOffs: {
                include: {
                    type: true,
                    resolved: true
                }
            },
            institutions: {
                select: {
                    institution: true
                }
            },
            directedInstitutions: true
        }
    }) as unknown as IEmployee[]

    employees.map((employee: IEmployee) => {
        employee.remainingDays = employee.day_count
        employee.dayOffs.forEach((dayOff) => {
            if (employee.remainingDays) {
                employee.remainingDays -= dayOff.days;
            }
        })
    })
    
    return employees;
}

export async function createEmployee(req: Request, res: Response) {
    const fields = {
        first_name: req.body.firstName,
        last_name: req.body.lastName,
        email: req.body.email,
        password: bcrypt.hashSync(req.body.password, 10),
        phone: req.body.phone,
        day_count: req.body.dayCount
    };

    const roles = req.body.roles ?
     req.body.roles.map((roleId: number) => {
        return {
            role: {
                connect: {
                    id: roleId
                }
            }
        }
    }) : []

    const institutions = req.body.institutions ?
     req.body.institutions.map((institutionId: number) => {
        return {
            institution: {
                connect: {
                    id: institutionId
                }
            }
        }
    }) : []

    prisma.employee.create({
        data: {
            ...fields,
            roles: {
                create: roles
            },
            institutions: {
                create: institutions
            }
        }
    }).then((created) => {
        return res.status(201).json(created)
    }).catch(error => {
        console.log(error)
        return res.status(500).json(error)
    })
}

export async function updateEmployee(req: Request, res: Response) {
    const fields = {
        first_name: req.body.firstName,
        last_name: req.body.lastName,
        email: req.body.email,
        password: bcrypt.hashSync(req.body.password, 10),
        phone: req.body.phone,
        day_count: req.body.dayCount
    };

    const roles = req.body.roles ? req.body.roles.map((roleId: number) => {
        return {
            role: {
                connect: {
                    id: roleId
                }
            }
        }
    }) : []

    const institutions = req.body.institutions ? req.body.institutions.map((institutionId: number) => {
        return {
            institution: {
                connect: {
                    id: institutionId
                }
            }
        }
    }) : []

    await prisma.userRole.deleteMany({
        where: {
            user_id: parseInt(req.params.id)
        }
    })

    await prisma.institutionEmployee.deleteMany({
        where: {
            employee_id: parseInt(req.params.id)
        }
    })

    prisma.employee.update({
        data: {
            ...fields,
            roles: {
                create: roles
            },
            institutions: {
                create: institutions
            }
        },
        where: {
            id: parseInt(req.params.id)
        }
    }).then((updated) => {
        return res.status(200).json(updated)
    }).catch(error => {
        console.log(error)
        return res.status(500).json(error)
    })
}

export async function deleteEmployee(req: Request, res: Response) {
    prisma.employee.delete({
        where: {
            id: parseInt(req.params.id)
        }
    }).then(() => {
        return res.status(204).json("deleted")
    })
}

export async function login(req: Request, res: Response) {
    prisma.employee.findFirst({
        where: {
            email: req.body.email
        }
    }).then((employee) => {
        if (employee) {
            if (bcrypt.compareSync(req.body.password, employee.password)) {
                const user = JSON.parse(JSON.stringify(employee));
                delete user.password;

                return res.status(200).json(user)
            } else {
                return res.status(401).json({
                    error: true,
                    messages: [
                        "Hibás jelszó!"
                    ]
                })
            }
        } else {
            return res.status(404).json({
                error: true,
                messages: [
                    "Nem található ilyen felhasználó!"
                ]
            })
        }
    })
}