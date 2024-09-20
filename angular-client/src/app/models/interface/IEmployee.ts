import { IEmployeeAddress } from './IEmployeeAddress';

export interface IEmployee {
  id: string;
  firstName: string;
  lastName: string;
  roleInCompany: string;
  salary: Number;
  hireDate: Date;
  officeId: string;
  employeeAddress: IEmployeeAddress;
}
