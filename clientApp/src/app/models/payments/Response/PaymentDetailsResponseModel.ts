import { PaymentMethodModel } from "./PaymentMethodModel";

export interface PaymentDetailsResponseModel {
  id: string;
  amount: number;
  currency: string;
  paymentMethods: PaymentMethodModel[];
}
