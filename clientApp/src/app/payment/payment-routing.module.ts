import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentErrorComponent } from './payment-error/payment-error.component';
import { PaymentMethodComponent } from './payment-method/payment-method.component';
import { PaymentSuccessComponent } from './payment-success/payment-success.component';
import { PaymentComponent } from './payment/payment.component';

const routes: Routes = [
  {
    path: '',
    component: PaymentComponent,
    children: [
      {
        path: "details/:id",
        component: PaymentDetailsComponent,
      },
      {
        path: "paymentMethod/:id",
        component: PaymentMethodComponent,
      },
      {
        path: "success",
        component: PaymentSuccessComponent,
      },
      {
        path: "500",
        component: PaymentErrorComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaymentRoutingModule { }
