import { DayOff } from "@prisma/client";
import { IDayOff } from "./day";
import { IGroup } from "./group";
import { IInstitution, InstitutionEmployeeHelper } from "./institution";
import { UserRoleHelper } from "./role";

export interface IEmployee {
    id: number;
    first_name: string;
    last_name: string;
    email: string;
    password: string;
    phone: string;
    day_count: number;
    prev_year_day_count: number;
    remainingDays?: number;
    group_id?: number;

    institutions: InstitutionEmployeeHelper[];
    directedInstitutions: IInstitution[];
    roles: UserRoleHelper[];
    dayOffs: IDayOff[];
    group?: IGroup;
    resolvedDayOffs: DayOff[];
}