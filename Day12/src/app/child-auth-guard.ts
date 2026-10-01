import { CanActivateFn } from '@angular/router';

export const childAuthGuard: CanActivateFn = (route, state) => {
  return true;
};
