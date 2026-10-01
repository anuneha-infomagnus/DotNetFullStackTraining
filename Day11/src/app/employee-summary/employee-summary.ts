import { Component } from '@angular/core';
import { Employee } from '../employee';

@Component({
  selector: 'app-employee-summary',
  standalone: false,
  templateUrl: './employee-summary.html',
  styleUrl: './employee-summary.css',
})
export class EmployeeSummary {

  employees: any[] = [];
  selectedEmployee: any;
  engineeringEmployees: any[] = [];

  constructor(private employeeService: Employee) {
    this.employees = this.employeeService.getEmployees();
    this.selectedEmployee = this.employeeService.getEmployeeById('EMP003');
    this.engineeringEmployees =
      this.employeeService.getEmployeesByDepartment('Engineering');
  }

}
