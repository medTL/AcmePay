using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Response;

public class PaymentDetailsModel
{
    [JsonProperty("id")] public Guid Id { get; set; }

    [JsonProperty("amount")] public decimal Amount { get; set; }

    [JsonProperty("currency")] public string Currency { get; set; }

    [JsonProperty("paymentMethods")] public IEnumerable<PaymentMethodModel> PaymentMethods { get; set; }
}