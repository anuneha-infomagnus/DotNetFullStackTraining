import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { EmployeeService } from '../services/employee';
import { Employee } from '../Models/employee';

@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css'
})
export class EmployeeList implements OnInit {

  employees: Employee[] = [];

  // Controls whether employee list is displayed
  showEmployees = false;

  // Controls edit mode
  editingEmployeeId: number | string | null = null;

  // Temporary employee data while editing
  editedEmployee: Employee = {
    id: 0,
    name: '',
    email: '',
    department: ''
  };

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    // Do NOT load employees automatically.
  }


  // ============================
  // GET - Load Employees
  // ============================

  loadEmployees(): void {

    this.employeeService.getEmployees().subscribe({
      next: (data) => {
        console.log('Employees received:', data);

        this.employees = data;
        this.showEmployees = true;
      },

      error: (error: HttpErrorResponse) => {
        console.error('Error loading employees:', error);
      }
    });
  }


  // ============================
  // POST - Add Employee
  // ============================

  addEmployee(
    name: string,
    email: string,
    department: string
  ): void {

    const nextId =
      this.employees.length > 0
        ? Math.max(
          ...this.employees.map(employee => Number(employee.id))
        ) + 1
        : 1;

    const newEmployee: Employee = {
      id: nextId,
      name: name,
      email: email,
      department: department
    };

    this.employeeService.addEmployee(newEmployee).subscribe({

      next: (employee) => {

        console.log('Employee added:', employee);

        alert('Employee added successfully!');

        this.loadEmployees();

      },

      error: (error) => {

        console.error('Error adding employee:', error);

        alert('Failed to add employee.');

      }

    });

  }

  // ============================
  // Start Editing
  // ============================

  editEmployee(employee: Employee): void {

    this.editingEmployeeId = employee.id;

    this.editedEmployee = {
      ...employee
    };
  }


  // ============================
  // PUT - Save Employee
  // ============================

  saveEmployee(): void {

    this.employeeService.updateEmployee(this.editedEmployee).subscribe({

      next: (updatedEmployee) => {

        console.log('Employee updated:', updatedEmployee);

        const index = this.employees.findIndex(
          employee => employee.id === updatedEmployee.id
        );

        if (index !== -1) {
          this.employees[index] = updatedEmployee;
        }

        this.editingEmployeeId = null;

        alert('Employee updated successfully!');
      },

      error: (error) => {
        console.error('Error updating employee:', error);
        alert('Failed to update employee.');
      }
    });
  }


  // ============================
  // Cancel Editing
  // ============================

  cancelEdit(): void {

    this.editingEmployeeId = null;
  }


  // ============================
  // DELETE
  // ============================

  deleteEmployee(id: number | string): void {

    if (!confirm('Are you sure you want to delete this employee?')) {
      return;
    }

    this.employeeService.deleteEmployee(id).subscribe({

      next: () => {

        console.log('Employee deleted:', id);

        this.employees = this.employees.filter(
          employee => String(employee.id) !== String(id)
        );

        alert('Employee deleted successfully!');

      },

      error: (error) => {

        console.error('Error deleting employee:', error);

        alert('Failed to delete employee.');

      }

    });

  }

}
