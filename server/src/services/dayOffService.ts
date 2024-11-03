import { PrismaClient } from "@prisma/client";
import { Request, Response } from "express";

const prisma = new PrismaClient()

export async function getDayOffs() {
    const dayOffs = await prisma.dayOff.findMany({
        include: {
            type: true,
            employee: true
        }
    })

    return dayOffs;
}

export async function createDayOff(request: Request, res: Response) {
    const fields = {
        to: request.body.to,
        from: request.body.from,
        days: request.body.days,
        reason: request.body.reason,
        typeId: request.body.typeId,
        employeeId: request.body.employeeId
    };

    prisma.dayOff.create({
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

export async function updateDayOff(request: Request, res: Response) {
    const fields = {
        to: request.body.to,
        from: request.body.from,
        days: request.body.days,
        reason: request.body.reason,
        typeId: request.body.typeId,
        employeeId: request.body.employeeId
    };

    prisma.dayOff.update({
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

export async function deleteDayOff(request: Request, res: Response) {
    prisma.dayOff.delete({
        where: {
            id: parseInt(request.params.id)
        }
    }).then(() => {
        return res.status(204).json("DELETED")
    }).catch((error) => {
        console.log(error);
        return res.status(500).json(error)
    })
}