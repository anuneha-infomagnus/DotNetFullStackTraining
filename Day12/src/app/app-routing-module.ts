import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { childAuthGuard } from './child-auth-guard';
import { Dashboard } from './dashboard/dashboard';
import { Employees } from './employees/employees';
import { authGuard } from './auth-guard';
const routes: Routes = [

  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },

  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard-module')
        .then(m => m.DashboardModule),
     canActivate: [authGuard]
  },
  {
    path: 'employees',
    component: Employees,
    canActivateChild: [childAuthGuard],
    children: [
      {
        path: 'details',
        component: Employees
      }
    ]
  },
  

  {
    path: 'employees/:id',
    component: Employees
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

