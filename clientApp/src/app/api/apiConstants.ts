import { ApiVersion } from "./ApiVersion";

export class ApiConstants {
  public static baseUrl = "http://localhost:5200";


  public static CreatePayment = `${ApiConstants.baseUrl}/${ApiVersion.V1_0}/Payments/CreatePayment`;
  public static PaymentDetail = `${ApiConstants.baseUrl}/${ApiVersion.V1_0}/Payments/PaymentDetail`;
  public static PaymentDetails = `${ApiConstants.baseUrl}/${ApiVersion.V1_0}/Payments/PaymentDetails`;
  public static PostPayments = `${ApiConstants.baseUrl}/${ApiVersion.V1_0}/Payments/Payment`;


}
