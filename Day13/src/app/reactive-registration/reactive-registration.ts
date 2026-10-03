import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-registration',
  standalone: false,
  templateUrl: './reactive-registration.html',
  styleUrl: './reactive-registration.css',
})
export class ReactiveRegistration {

  employeeForm = new FormGroup({

    employeeId: new FormControl('', [
      Validators.required,
      Validators.pattern('EMP[0-9]{4}')
    ]),

    employeeName: new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]),

    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),

    department: new FormControl('', [
      Validators.required
    ])

  });
  registerEmployee() {

    if (this.employeeForm.invalid) {

      this.employeeForm.markAllAsTouched();

      return;
    }

    console.log('Reactive Form Submitted:');

    console.log(this.employeeForm.value);

    alert('Reactive Form Submitted Successfully!');

  }

}
