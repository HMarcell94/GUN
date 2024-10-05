import { IEmployee } from "./employee";

export interface IRole {
    id: number;
    tag: string;
    name: string;

    users: UserRoleHelper[];
}

export interface UserRoleHelper {
    user_id: number;
    role_id: number;

    user: IEmployee;
    role: IRole;
}