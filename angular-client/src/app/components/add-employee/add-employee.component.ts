import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { IOffice } from '../../models/interface/IOffice';
import { OfficeService } from '../../services/office/office.service';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, CommonModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css',
})
export class AddEmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  offices: IOffice[] = [];
  employeeService = inject(EmployeeService);
  officeService = inject(OfficeService);
  fb = inject(FormBuilder);
  router = inject(Router);

  constructor() {
    this.employeeForm = this.fb.group({
      roleInCompany: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      salary: [0, Validators.required],
      homeAddress: ['', Validators.required],
      city: ['', Validators.required],
      hireDate: ['', Validators.required],
      officeId: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.loadOffices();
  }

  loadOffices() {
    this.officeService.getOffices().subscribe({
      next: (result: IOffice[]) => {
        console.log(result);
        this.offices = result;
      },
    });
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const employee = {
        ...this.employeeForm.value,
        employeeAddress: {
          homeAddress: this.employeeForm.value.homeAddress,
          city: this.employeeForm.value.city,
        },
      };

      this.employeeService.addEmployee(employee).subscribe({
        next: () => {
          alert('New employee added seccessfully');
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error('Error adding employee', error);
        },
      });
    }
  }
}
