import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee-registration',
  standalone: false,
  templateUrl: './employee-registration.html',
  styleUrl: './employee-registration.css',
})
export class EmployeeRegistration {

  employeeId = '';
  employeeName = '';
  email = '';
  phone = '';
  joiningDate = '';
  department = '';
  designation = '';
  employmentType = '';

  submitted = false;

  registerEmployee(form: NgForm) {

    // Check whether the complete form is valid
    if (form.invalid) {

      // Show validation messages for all fields
      form.control.markAllAsTouched();

      this.submitted = false;

      alert('Please complete all required fields correctly.');

      return;
    }

    // Form is valid
    this.submitted = true;

    console.log('Employee Registered:', {
      employeeId: this.employeeId,
      employeeName: this.employeeName,
      email: this.email,
      phone: this.phone,
      joiningDate: this.joiningDate,
      department: this.department,
      designation: this.designation,
      employmentType: this.employmentType
    });

    alert('Employee Registered Successfully!');

  }


  resetForm(form: NgForm) {

    form.resetForm();

    this.employeeId = '';
    this.employeeName = '';
    this.email = '';
    this.phone = '';
    this.joiningDate = '';
    this.department = '';
    this.designation = '';
    this.employmentType = '';

    this.submitted = false;

  }

}
