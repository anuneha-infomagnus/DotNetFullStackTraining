import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Employee {

  employees = [
    {
      name: 'Ananya Reddy',
      id: 'EMP001',
      department: 'Engineering',
      role: 'Software Developer',
      status: 'Active'
    },
    {
      name: 'Rahul Kumar',
      id: 'EMP002',
      department: 'Human Resources',
      role: 'HR Executive',
      status: 'Active'
    },
    {
      name: 'Sneha Rao',
      id: 'EMP003',
      department: 'Finance',
      role: 'Financial Analyst',
      status: 'On Leave'
    },
    {
      name: 'Vikram Kumar',
      id: 'EMP004',
      department: 'Engineering',
      role: 'Backend Developer',
      status: 'Pending'
    }
  ];
  getEmployees() {
    return this.employees;
  }
  getActiveEmployees() {
    return this.employees.filter(employee => employee.status === 'Active');
  }
  getOnLeaveEmployees() {
    return this.employees.filter(employee => employee.status === 'On Leave');
  }
  getPendingEmployees() {
    return this.employees.filter(employee => employee.status === 'Pending');
  }
  getEmployeeById(id: string) {
    return this.employees.find(employee => employee.id === id);
  }
  getEmployeesByDepartment(department: string) {
    return this.employees.filter(
      employee => employee.department === department
    );
  }

}
