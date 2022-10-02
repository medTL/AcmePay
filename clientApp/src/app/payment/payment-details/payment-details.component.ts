import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { localStorageKeys } from 'src/app/models/Enums/LocalStrorageKeys';
import { PaymentDetailsResponseModel } from 'src/app/models/payments/Response/PaymentDetailsResponseModel';
import { PaymentMethodModel } from 'src/app/models/payments/Response/PaymentMethodModel';
import { PaymentService } from 'src/app/services/payment-service.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.scss']
})
export class PaymentDetailsComponent  implements OnInit, OnDestroy {
  paymentDetailSubscription: Subscription = new Subscription();
  paymentId: string = "";
  paymentDetails?: PaymentDetailsResponseModel;
  constructor(private paymentService: PaymentService,
    private router: Router,
     private route: ActivatedRoute) {

   }

  ngOnInit(): void {
    this.paymentId =  this.route.snapshot.params['id'];
    if(this.paymentId !== "")
    {
      this.paymentDetailSubscription = this.paymentService.PaymentDetails(this.paymentId).subscribe(
        data => {
          this.paymentDetails = data?.data;
          localStorage.setItem(localStorageKeys.PAYMENT_ID, this.paymentDetails.id);
          localStorage.setItem(localStorageKeys.AMOUNT, this.paymentDetails.amount.toString());
          localStorage.setItem(localStorageKeys.CURRENCY, this.paymentDetails.currency);
        }
      )
    }
  }

  selectPaymentMethod(name: string): void
  {
    this.router.navigate(["payments/paymentMethod", name]);
  }

  ngOnDestroy(): void {
      if(this.paymentDetailSubscription) this.paymentDetailSubscription.unsubscribe;
  }

}
