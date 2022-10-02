import { AbstractControl } from "@angular/forms";


export function LuhnValidator(control: AbstractControl) : { [key: string]: boolean } | null {



    let arr = (control.value + "")
    .split("")
    .reverse()
    .map((x) => parseInt(x));
            let lastDigit = arr.splice(0, 1)[0];
            let sum = arr.reduce(
              (acc, val, i) => (i % 2 !== 0 ? acc + val : acc + ((val * 2) % 9) || 9),
              0
            );
            sum += lastDigit;

       let valid = (sum % 10 == 0) ;
        if(control.value && !valid) {
          console.log("NOT VLID");
          return {"LuhnValidation": true}
        }
  return null;

}
