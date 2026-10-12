import { Routes } from '@angular/router';

import { Login } from './login/login';
import { AdminDashboard } from './admin-dashboard/admin-dashboard';
import { EmployeeDashboard } from './employee-dashboard/employee-dashboard';
import { authGuard } from './guards/auth-guard';

export const routes: Routes = [

  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },

  {
    path: 'login',
    component: Login
  },

  {
    path: 'admin',
    component: AdminDashboard,
    canActivate: [authGuard],
    data: {
      role: 'Admin'
    }
  },

  {
    path: 'employee',
    component: EmployeeDashboard,
    canActivate: [authGuard],
    data: {
      role: 'Employee'
    }
  }

];
