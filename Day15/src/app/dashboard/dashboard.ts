import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

  userName = '';

  constructor() {
    const user = localStorage.getItem('loggedInUser');

    if (user) {
      const loggedInUser = JSON.parse(user);
      this.userName = loggedInUser.name;
    }
  }

  logout() {
    localStorage.removeItem('loggedInUser');
    sessionStorage.removeItem('currentSession');

    document.cookie =
      'peoplehubLoggedIn=; path=/; max-age=0; SameSite=Lax';

    window.location.href = '/';
  }
}
