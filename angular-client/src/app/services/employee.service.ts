import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmployee } from '../models/interface/IEmployee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  apiUrl = 'http://localhost:5000/api/employees';

  constructor(private http: HttpClient) {}

  getAllEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.apiUrl);
  }

  getEmployeesByOffice(officeId: string): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(`${this.apiUrl}/${officeId}`);
  }

  getEmployee(employeeId: string, officeId: string): Observable<IEmployee> {
    return this.http.get<IEmployee>(`${this.apiUrl}/${officeId}/${employeeId}`);
  }

  addEmployee(employee: IEmployee): Observable<IEmployee> {
    return this.http.post<IEmployee>(this.apiUrl, employee);
  }

  updateEmployee(employeeId: string, employee: IEmployee): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${employeeId}`, employee);
  }

  deleteEmployee(employeeId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${employeeId}`);
  }
}
