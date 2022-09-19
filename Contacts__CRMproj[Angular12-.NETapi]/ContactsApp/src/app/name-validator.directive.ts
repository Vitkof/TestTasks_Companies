import { Directive } from '@angular/core';
import { AbstractControl, Validator, NG_VALIDATORS } from '@angular/forms';

@Directive({
  selector: '[appNameValidator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: NameValidatorDirective,
    multi: true
  }]
})
export class NameValidatorDirective implements Validator {

  constructor() { }
  validate(control: AbstractControl): {[key: string]: any} | null {

    let nameRgEx: RegExp = /^[a-zA-Z\s]*$/
    let valid =
      !control.value || nameRgEx.test(control.value)

    return valid ? null : { 'nameInvalid': true }
  }
}
