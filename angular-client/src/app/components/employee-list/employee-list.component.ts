import { Component, inject, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { IEmployee } from '../../models/interface/IEmployee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, DatePipe],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css',
})
export class EmployeeListComponent implements OnInit {
  router = inject(Router);
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

  onDelete(id: string) {
    const isDelete = window.confirm('Are you sure you want to delete?');
    if (isDelete) {
      this.employeeService.deleteEmployee(id).subscribe({
        next: () => {
          alert('Employee deleted');
          this.loadEmployees();
        },
        error: (error) => {
          console.error('Error occurred deleting employee', error);
        },
      });
    }
  }

  onUpdate(employeeId: string, officeId: string) {
    this.router.navigate(['/update-employee', { employeeId, officeId }]);
  }
}
