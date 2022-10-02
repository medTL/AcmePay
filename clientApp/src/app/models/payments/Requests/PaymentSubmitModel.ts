import { SepaPaymentModel } from "./SepaPaymentModel";
import { VisaPaymentModel } from "./VisaPaymentModel";

export interface PaymentSubmitModel {
  paymentId: string;
  amount: number;
  currency: string;
  visaPaymentModel?: VisaPaymentModel;
  sepaPaymentModel?: SepaPaymentModel;
}
