import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AlgoValidationNames } from 'src/app/models/Enums/AlgoValidationNames';
import { PaymentMethodNames } from 'src/app/models/Enums/PaymentMethodNames';
import { SepaPaymentModel } from 'src/app/models/payments/Requests/SepaPaymentModel';
import { VisaPaymentModel } from 'src/app/models/payments/Requests/VisaPaymentModel';
import { FieldModel } from 'src/app/models/payments/Response/FieldModel';
import { LuhnValidator } from 'src/app/models/validators/LuhnValdiator';



@Component({
  selector: 'app-payment-form',
  templateUrl: './payment-form.component.html',
  styleUrls: ['./payment-form.component.scss']
})
export class PaymentFormComponent implements OnInit {

  @Input() fields:FieldModel[] = [];
  @Input() type:  string = "";
  @Output() visaValues = new EventEmitter<VisaPaymentModel>();
  @Output() sepaValues = new EventEmitter<SepaPaymentModel>();
  form?: FormGroup;

  constructor(private fb:FormBuilder) {
    this.form = new FormGroup(
      {
        fields: this.fb.array([]),
      }
     );
   }

   get fieldControls() {
    return this.form?.controls['fields'] as FormArray;
   }

  ngOnInit(): void {
    if(this.fields)
    {

    this.fields.forEach(item => {
      const validationsArray:ValidatorFn[] = [];
        if (item.validator.required) {
          validationsArray.push(
            Validators.required
          );
        }
        if (item.validator.pattern) {
          validationsArray.push(
            Validators.pattern(item.validator.pattern)
          );
        }
        if (item.validator.minLength) {
          validationsArray.push(
            Validators.minLength(item.validator.minLength)
          );
        }
        if (item.validator.maxLength) {
          validationsArray.push(
            Validators.maxLength(item.validator.maxLength)
          );
        }
        if(item.validator.algorithmCheck)
        {
          if(item.validator.algorithmCheck === AlgoValidationNames.LUHN)
          {
            console.log(item.name)
            validationsArray.push(
              LuhnValidator
            );
          }
        }
      const control = this.fb.group({[item.name] : new FormControl("", Validators.compose(validationsArray))});
      this.fieldControls.push(control);
    });
  }
  }

  Submit() {
    if(!this.form?.valid)
    {
      console.log("form invalid");
      this.form?.markAllAsTouched();
      return;
    }
    if(this.type === PaymentMethodNames.VISA)
    {
       const visaModel: VisaPaymentModel = {
        cardNumber: this.fieldControls.value[0].CardNumber,
        expirationDate: this.fieldControls.value[1].ExpirationDate,
        cvc: parseInt(this.fieldControls.value[2].CVC),
        cardHolder: this.fieldControls.value[3].CardHolder
      }
      this.visaValues.emit(visaModel);
      return;
    }

    if(this.type === PaymentMethodNames.SEPA)
    {

      const sepaModel: SepaPaymentModel = {
        iban: this.fieldControls.value[0].IBAN,
        bic: this.fieldControls.value[1].BIC,
        holderName: this.fieldControls.value[2].HolderName
      }
      this.sepaValues.emit(sepaModel);
      return;
    }
  }


}
