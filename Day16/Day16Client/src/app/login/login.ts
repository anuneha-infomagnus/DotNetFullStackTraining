import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Auth } from '../services/auth';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  private authService = inject(Auth);

  username = '';
  password = '';
  message = '';

  login() {

    const request = {
      username: this.username,
      password: this.password
    };

    this.authService.login(request).subscribe({
      next: (response: any) => {

        console.log(response);

        const role = response.roles[0];

        sessionStorage.setItem('role', role);

        this.message = 'Login successful!';

        if (role === 'Admin') {
          window.location.href = '/admin';
        }
        else if (role === 'Employee') {
          window.location.href = '/employee';
        }
      },

      error: (error) => {
        console.error(error);
        this.message = 'Invalid username or password';
      }
    });
  }
}
