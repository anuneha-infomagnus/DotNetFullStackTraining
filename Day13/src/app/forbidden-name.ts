import { Directive, Input, forwardRef } from '@angular/core';
import {
  AbstractControl,
  NG_VALIDATORS,
  ValidationErrors,
  Validator
} from '@angular/forms';

@Directive({
  selector: '[appForbiddenName]',
  standalone: false,
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => ForbiddenName),
      multi: true
    }
  ]
})
export class ForbiddenName implements Validator {

  @Input('appForbiddenName')
  forbiddenName = '';

  validate(control: AbstractControl): ValidationErrors | null {

    if (
      control.value &&
      control.value.toLowerCase() === this.forbiddenName.toLowerCase()
    ) {
      return {
        forbiddenName: true
      };
    }

    return null;
  }
}
