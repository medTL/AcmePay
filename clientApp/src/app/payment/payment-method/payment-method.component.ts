import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { localStorageKeys } from 'src/app/models/Enums/LocalStrorageKeys';
import { PaymentMethodNames } from 'src/app/models/Enums/PaymentMethodNames';
import { PaymentSubmitModel } from 'src/app/models/payments/Requests/PaymentSubmitModel';
import { SepaPaymentModel } from 'src/app/models/payments/Requests/SepaPaymentModel';
import { VisaPaymentModel } from 'src/app/models/payments/Requests/VisaPaymentModel';
import { PaymentMethodModel } from 'src/app/models/payments/Response/PaymentMethodModel';
import { PaymentService } from 'src/app/services/payment-service.service';

@Component({
  selector: 'app-payment-method',
  templateUrl: './payment-method.component.html',
  styleUrls: ['./payment-method.component.scss']
})
export class PaymentMethodComponent implements OnInit, OnDestroy {
  title = "";
  paymentMethodDetailsSubscription: Subscription = new Subscription();
  SubmitPaymentSubscription: Subscription = new Subscription();
  paymentMethod?: PaymentMethodModel;
  loading: boolean = true;

  constructor(
    private router: Router,
    private paymentService: PaymentService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.title = this.route.snapshot.params['id'];
    this.paymentMethodDetailsSubscription=  this.paymentService.paymentmethodDetails(this.title).subscribe(
      data => {
        this.paymentMethod = data?.data;

        this.loading= false;
      }
    )
  }

  getVisaFormData(values: VisaPaymentModel)
  {
    const model: PaymentSubmitModel = {
      paymentId: localStorage.getItem(localStorageKeys.PAYMENT_ID) ?? "",
      amount: parseFloat(localStorage.getItem(localStorageKeys.AMOUNT) ?? ""),
      currency: localStorage.getItem(localStorageKeys.CURRENCY) ?? "",
      visaPaymentModel: values
    }

    this.SubmitPaymentSubscription = this.paymentService.paymentSubmit(model).subscribe(
      data => {
        this.router.navigate(["payments/success"]);
      }
    )


  }

  getSepaFormData(values: SepaPaymentModel)
  {
    console.log("SUBMITING");
    console.log(values);
    const model: PaymentSubmitModel = {
          paymentId: localStorage.getItem(localStorageKeys.PAYMENT_ID) ?? "",
          amount: parseFloat(localStorage.getItem(localStorageKeys.AMOUNT) ?? ""),
          currency: localStorage.getItem(localStorageKeys.CURRENCY) ?? "",
          sepaPaymentModel: values
        }
        this.SubmitPaymentSubscription = this.paymentService.paymentSubmit(model).subscribe(
          data => {
            this.router.navigate(["payments/success"]);
          }
        )

  }

  ngOnDestroy(): void {
      if(this.paymentMethodDetailsSubscription)
      this.paymentMethodDetailsSubscription.unsubscribe();
      if(this.SubmitPaymentSubscription)
       this.SubmitPaymentSubscription.unsubscribe();
      this.loading = false;
  }
}
