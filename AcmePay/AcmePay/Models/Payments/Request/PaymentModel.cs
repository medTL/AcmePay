using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Request;

public class PaymentModel
{
    [JsonProperty("amount")] [Required] public decimal Amount { get; set; }

    [JsonProperty("description")]
    [Required]
    public string Description { get; set; }

    [JsonProperty("currency")] [Required] public string Currency { get; set; }
}