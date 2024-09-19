import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

export const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
    title: 'Log In',
  },
  {
    path: 'sign-up',
    component: RegisterComponent,
    title: 'Sign Up',
  },
];
