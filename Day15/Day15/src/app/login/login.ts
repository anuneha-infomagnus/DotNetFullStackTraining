import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  email = '';
  password = '';

  constructor(private router: Router) { }

  login() {
    const user = {
      name: 'Anuneha Peteti',
      email: this.email,
      department: 'IT'
    };

    localStorage.setItem(
      'loggedInUser',
      JSON.stringify(user)
    );

    sessionStorage.setItem(
      'currentSession',
      'active'
    );

    document.cookie =
      'peoplehubLoggedIn=true; path=/; max-age=3600; SameSite=Lax';

    this.router.navigate(['/dashboard']);
  }
}
