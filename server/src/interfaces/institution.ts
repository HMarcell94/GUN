import { IEmployee } from "./employee";
import { IGroup } from "./group";

export interface IInstitution {
    id: number;
    name: string;
    city: string;
    director_id: number;

    director: IEmployee;
    employees: InstitutionEmployeeHelper[];
    groups: IGroup[];
}

export interface InstitutionEmployeeHelper {
    institution_id: number;
    employee_id: number

    employee: IEmployee;
    instituion: IInstitution;
}