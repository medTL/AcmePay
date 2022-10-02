using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Request;

public class PaymentSubmitModel
{
    [JsonProperty("paymentId")] public Guid PaymentId { get; set; }

    [JsonProperty("amount")] public decimal Amount { get; set; }

    [JsonProperty("currency")] public string Currency { get; set; }

    [JsonProperty("visaPaymentModel")] public VisaPaymentModel? VisaPaymentModel { get; set; }

    [JsonProperty("sepaPaymentModel")] public SepaPaymentModel? SepaPaymentModel { get; set; }
}