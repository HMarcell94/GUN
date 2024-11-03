import { PrismaClient } from "@prisma/client";
import { Request, Response } from "express";

const prisma = new PrismaClient()

export async function getGroups() {
    const groups = await prisma.group.findMany({
        include: {
            type: true,
            employee: true
        }
    })

    return groups;
}

export async function createGroup(request: Request, res: Response) {
    const fields = {
        to: request.body.to,
        from: request.body.from,
        days: request.body.days,
        reason: request.body.reason,
        typeId: request.body.typeId,
        employeeId: request.body.employeeId
    };

    prisma.group.create({
        data: {
            to: fields.to,
            from: fields.from,
            days: fields.days,
            reason: fields.reason,
            type_id: fields.typeId,
            employee_id: fields.employeeId
        }
    }).then((created) => {
        return res.status(201).json(created)
    }).catch((error) => {
        console.log(error);
        return res.status(500).json(error)
    })
}

export async function updateGroup(request: Request, res: Response) {
    const fields = {
        to: request.body.to,
        from: request.body.from,
        days: request.body.days,
        reason: request.body.reason,
        typeId: request.body.typeId,
        employeeId: request.body.employeeId
    };

    prisma.group.update({
        data: {
            to: fields.to,
            from: fields.from,
            days: fields.days,
            reason: fields.reason,
            type_id: fields.typeId,
            employee_id: fields.employeeId
        },
        where: {
            id: parseInt(request.params.id)
        }
    }).then((updated) => {
        return res.status(200).json(updated)
    }).catch((error) => {
        console.log(error);
        return res.status(500).json(error)
    })
}

export async function deleteGroup(request: Request, res: Response) {
    prisma.group.delete({
        where: {
            id: parseInt(request.params.id)
        }
    }).then(() => {
        return res.status(204).json("DELETED")
    }).catch((error) => {
        console.log(error);
    })
}
