import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CreatePaymentModel } from './models/payments/Requests/CreatePaymentModel';
import { PaymentService } from './services/payment-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit, OnDestroy {
  title = 'clientApp';
  loading:boolean = true;
  public createpaymentSubscription: Subscription = new Subscription();

  constructor(private paymentService: PaymentService, private router: Router)
  {

  }
  ngOnInit():void {
    const model: CreatePaymentModel = {
      amount: Math.floor(Math.random() * (1000 - 100) + 100) / 100,
      description: "Pay this payment",
      currency: "USD"
    }
    this.createpaymentSubscription = this.paymentService.CreatePayment(model).subscribe(
      data => {
          if(data){
            setTimeout(() => {
              this.loading = false;
              this.router.navigate(["payments/details", data.data]);
            },1000)

          }
      }, error => {
          this.loading= false;
          this.router.navigate(["payments/500"]);
      }
    )
  }


  ngOnDestroy(): void {
    if(this.createpaymentSubscription)this.createpaymentSubscription.unsubscribe();
  }
}
