import { Component, inject, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { IEmployee } from '../../models/interface/IEmployee';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, DatePipe],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css',
})
export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeService);
  employees: IEmployee[] = [];
  isLoader: boolean = true;

  //constructor(employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getAllEmployees().subscribe({
      next: (result: IEmployee[]) => {
        this.employees = result;
        this.isLoader = false;
      },
      error: (error) => {
        console.log('Error occured fetching data', error);
        this.isLoader = false;
      },
    });
  }
}
