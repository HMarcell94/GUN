import { IDayOff } from "./day";
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
    remainingDays?: number;

    institutions: InstitutionEmployeeHelper[];
    directedInstitutions: IInstitution[];
    roles: UserRoleHelper[];
    dayOffs: IDayOff[];
}