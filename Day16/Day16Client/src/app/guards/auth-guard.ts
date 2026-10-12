import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { Auth } from '../services/auth';

export const authGuard: CanActivateFn = (route) => {

  const auth = inject(Auth);
  const router = inject(Router);

  const role = auth.getRole();
  const requiredRole = route.data['role'];

  if (!role) {
    router.navigate(['/login']);
    return false;
  }

  if (requiredRole && role !== requiredRole) {
    router.navigate(['/login']);
    return false;
  }

  return true;
};
