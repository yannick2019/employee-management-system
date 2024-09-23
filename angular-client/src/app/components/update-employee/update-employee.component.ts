import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { IOffice } from '../../models/interface/IOffice';
import { EmployeeService } from '../../services/employee.service';
import { OfficeService } from '../../services/office/office.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-update-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './update-employee.component.html',
  styleUrl: './update-employee.component.css',
})
export class UpdateEmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  offices: IOffice[] = [];
  employeeId: string;
  officeId: string;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private officeService: OfficeService,
    private route: ActivatedRoute,
    private router: Router
  ) {
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
    this.employeeId = this.route.snapshot.paramMap.get('employeeId')!;
    this.officeId = this.route.snapshot.paramMap.get('officeId')!;
  }

  ngOnInit(): void {
    this.officeService
      .getOffices()
      .subscribe((offices) => (this.offices = offices));

    this.employeeService.getEmployee(this.employeeId, this.officeId).subscribe({
      next: (employee) => {
        const formattedHireDate = this.formattedDate(employee.hireDate);
        this.employeeForm.patchValue({
          roleInCompany: employee.roleInCompany,
          firstName: employee.firstName,
          lastName: employee.lastName,
          salary: employee.salary,
          homeAddress: employee.employeeAddress?.homeAddress || '',
          city: employee.employeeAddress?.city || '',
          hireDate: formattedHireDate,
          officeId: employee.officeId,
        });
      },
      error: (error) => {
        console.error('Error fetching employee data', error);
      },
    });
  }

  formattedDate(date: Date | string): string {
    const dateObj = typeof date === 'string' ? new Date(date) : date;
    const year = dateObj.getFullYear();
    const month = ('0' + (dateObj.getMonth() + 1)).slice(-2);
    const day = ('0' + dateObj.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const updatedEmployee = {
        ...this.employeeForm.value,
        employeeAddress: {
          homeAddress: this.employeeForm.value.homeAddress,
          city: this.employeeForm.value.city,
        },
      };

      this.employeeService
        .updateEmployee(this.employeeId, updatedEmployee)
        .subscribe({
          next: () => {
            this.router.navigate(['/employees']);
          },
          error: (error) => {
            console.error('Error updating employee', error);
          },
        });
    }
  }
}
