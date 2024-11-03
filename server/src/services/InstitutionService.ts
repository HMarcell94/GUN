import { PrismaClient } from "@prisma/client";
import { IInstitution } from "../interfaces/institution";
import { Request, Response } from 'express'

const prisma = new PrismaClient();

export async function getInstitutions() {
    const data = await prisma.institution.findMany({
        include: {
            director: true,
            groups: true,
            employees: {
                include: {
                    employee: {
                        include: {
                            dayOffs: {
                                include: {
                                    type: true
                                }
                            }
                        }
                    }
                }
            }
        }
    }) as IInstitution[]

    data.map((institution) => {
        institution?.employees.map((employee) => {
            employee.employee.remainingDays = employee.employee.day_count
            employee.employee.dayOffs.forEach((dayOff) => {
                if (employee.employee.remainingDays) {
                    employee.employee.remainingDays -= dayOff.days;
                }
            })
        })
    })

    return data;

}

export async function createInstitution(req: Request, res: Response) {
    const fields = req.body;
    prisma.institution.create({
        data: {
            name: fields.name,
            city: fields.city,
            director: {
                connect: {
                    id: fields.directorId
                }
            }
        }
    }).then((created) => {
        return res.status(201).json(created)
    })
}

export async function updateInstitution(req: Request, res: Response) {
    const fields = req.body;

    prisma.institution.update({
        data: {
            name: fields.name,
            city: fields.city,
            director: {
                connect: {
                    id: fields.directorId
                }
            }
        },
        where: {
            id: parseInt(req.params.id)
        }
    }).then(updated => {
        return res.status(200).json(updated)
    })
}

export async function deleteInstitution(req: Request, res: Response) {
    prisma.institution.delete({
        where: {
            id: parseInt(req.params.id)
        }
    }).then(() => {
        return res.status(204).json("deleted")
    })
}