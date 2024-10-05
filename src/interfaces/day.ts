import { IEmployee } from "./employee";

export interface IDayOffType {
    id: number;
    name: string;

    dayOffs: IDayOff[];
}

export interface IDayOff {
    id: number;
    employee_id: number;
    from: Date;
    to: Date;
    days: number;
    type_id: number;
    reason?: string;
    resolved_by?: number;
    resolved_at?: Date;
    is_plan: boolean;

    employee: IEmployee;
    type: IDayOffType;
    resolved: IEmployee;
}