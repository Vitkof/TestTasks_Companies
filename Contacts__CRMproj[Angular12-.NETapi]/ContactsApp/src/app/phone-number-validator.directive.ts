import { Directive } from '@angular/core';
import { AbstractControl, Validator, NG_VALIDATORS } from '@angular/forms';

@Directive({
  selector: '[appPhoneNumberValidator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: PhoneNumberValidatorDirective,
    multi: true
  }]
})
export class PhoneNumberValidatorDirective implements Validator {

  constructor() { }
  validate(control: AbstractControl): {[key: string]: any} | null {

    let numberRgEx: RegExp = /^\+[0-9]*$/
    
    let valid =
      !control.value || 
      (numberRgEx.test(control.value) &&
      control.value.length > 11)

    return valid ? null : { 'phoneNumberInvalid': true }
  }
}
