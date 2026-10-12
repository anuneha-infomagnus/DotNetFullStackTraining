import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class Auth {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5049/api/Auth';

  login(request: { username: string; password: string }) {
    return this.http.post<any>(
      `${this.apiUrl}/login`,
      request,
      {
        withCredentials: true
      }
    );
  }

  logout() {
    return this.http.post(
      `${this.apiUrl}/logout`,
      {},
      {
        withCredentials: true
      }
    );
  }

  getRole(): string | null {
    return sessionStorage.getItem('role');
  }

  isLoggedIn(): boolean {
    return sessionStorage.getItem('role') !== null;
  }
}
