import { PrismaClient } from "@prisma/client";

const prisma = new PrismaClient();

export async function getRoles() {
    const roles = await prisma.role.findMany();
    
    return roles;
}

export async function checkRole(
    roleId: number,
    userId: number
) {
    const user = await prisma.employee.findFirst({
        where: {
            id: userId
        },
        include: {
            roles: {
                include: {
                    role: true
                }
            }
        }
    })

    return user?.roles.some((role) => {
        return role.role.id === roleId
    }) as boolean
}