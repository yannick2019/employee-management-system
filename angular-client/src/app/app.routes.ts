import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
    title: 'Log In',
  },
  {
    path: 'sign-up',
    component: RegisterComponent,
    title: 'Sign Up',
  },
  {
    path: 'employees',
    component: HomeComponent,
    title: 'All emplyees',
    // children: [
    //   {
    //     path: 'new-employee',
    //     component: AddEmployeeComponent,
    //     title: 'Add New Employee',
    //   },
    // ],
  },
  {
    path: 'new-employee',
    component: AddEmployeeComponent,
    title: 'Add New Employee',
  },
  { path: '**', component: PageNotFoundComponent },
];
