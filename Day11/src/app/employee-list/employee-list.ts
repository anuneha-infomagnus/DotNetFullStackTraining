import { Component } from '@angular/core';
import { Employee } from '../employee';

@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css',
})
export class EmployeeList {

  employees: any[] = [];
  activeEmployees: any[] = [];
  onLeaveEmployees: any[] = [];
  pendingEmployees: any[] = [];

  constructor(private employeeService: Employee) {
    this.employees = this.employeeService.getEmployees();
    this.activeEmployees = this.employeeService.getActiveEmployees();
    this.onLeaveEmployees = this.employeeService.getOnLeaveEmployees();
    this.pendingEmployees = this.employeeService.getPendingEmployees();
  }

}
