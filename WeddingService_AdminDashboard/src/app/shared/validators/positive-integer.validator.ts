import {AbstractControl, ValidationErrors } from '@angular/forms';

export class PositiveNumberValidator {

    static nonZero(control: AbstractControl): ValidationErrors | null {
        const isNotOk = Number(control.value) <= 0;
        return isNotOk ? { nonPositive: { value: control.value } } : null;
    }
}
