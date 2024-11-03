import { IEmployee } from "./employee";

export interface IGroupType {
    id: number;
    name: string;

    groups: IGroup[];
}

export interface IGroup {
    id: number;
    employee_id: number;
    from: Date;
    to: Date;
    days: number;
    type_id: number;
    reason?: string;

    employee: IEmployee;
    type: IGroupType;
}
