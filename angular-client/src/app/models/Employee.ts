import { EmployeeAddress } from './EmployeeAddress';

export interface Employee {
  id: string;
  firstName: string;
  lastName: string;
  roleInCompany: string;
  salary: Number;
  hireDate: Date;
  officeId: string;
  employeeAddress: EmployeeAddress;
}
