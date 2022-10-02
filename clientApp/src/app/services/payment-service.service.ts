import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiConstants } from '../api/apiConstants';
import { CreatePaymentModel } from '../models/payments/Requests/CreatePaymentModel';
import { PaymentSubmitModel } from '../models/payments/Requests/PaymentSubmitModel';
import { PaymentDetailsResponseModel } from '../models/payments/Response/PaymentDetailsResponseModel';
import { PaymentMethodModel } from '../models/payments/Response/PaymentMethodModel';
import { ServerResponse } from '../models/ServerResponse';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private headers;

  constructor(private http: HttpClient) {
    this.headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
   }

   /**
    * Create payment
    * @param model
    * @returns
    */
   CreatePayment(model: CreatePaymentModel): Observable<ServerResponse<any>> {
      return this.http.post<ServerResponse<any>>
      (ApiConstants.CreatePayment, model, this.headers);
   }

   /**
    * Get payment details
    * @param id
    * @returns
    */
   PaymentDetails(id: string): Observable<ServerResponse<PaymentDetailsResponseModel>> {
      return this.http.get<ServerResponse<PaymentDetailsResponseModel>>
      (`${ApiConstants.PaymentDetail}?id=${id}`);
   }

   /**
    * Get payment method details
    * @param name
    * @returns
    */
   paymentmethodDetails(name: string): Observable<ServerResponse<PaymentMethodModel>>
   {
      return this.http.get<ServerResponse<PaymentMethodModel>>
      (`${ApiConstants.PaymentDetails}/${name}`);
   }

   /**
    * Submit payment
    * @param model
    * @returns
    */
   paymentSubmit(model: PaymentSubmitModel):Observable<any>
   {
    return this.http.post(ApiConstants.PostPayments, model);
   }
}
