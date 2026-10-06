import { HttpInterceptorFn } from '@angular/common/http';
import { finalize, tap } from 'rxjs';

export const loggingInterceptor: HttpInterceptorFn = (req, next) => {

  console.log(
    'HTTP Request:',
    req.method,
    req.url
  );

  return next(req).pipe(

    tap({
      next: (event) => {
        console.log(
          'HTTP Response/Event:',
          event
        );
      },

      error: (error) => {
        console.error(
          'HTTP Error:',
          error
        );
      }
    }),

    finalize(() => {
      console.log(
        'HTTP Request completed:',
        req.url
      );
    })

  );
};
