import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaymentRoutingModule } from './payment-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentService } from '../services/payment-service.service';
import { PaymentComponent } from './payment/payment.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentErrorComponent } from './payment-error/payment-error.component';
import { PaymentMethodComponent } from './payment-method/payment-method.component';
import { PaymentFormComponent } from './payment-form/payment-form.component';
import { PaymentSuccessComponent } from './payment-success/payment-success.component';


@NgModule({
  declarations: [
    PaymentComponent,
    PaymentDetailsComponent,
    PaymentErrorComponent,
    PaymentMethodComponent,
    PaymentFormComponent,
    PaymentSuccessComponent
  ],
  imports: [
    CommonModule,
    PaymentRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [PaymentService]
})
export class PaymentModule { }
