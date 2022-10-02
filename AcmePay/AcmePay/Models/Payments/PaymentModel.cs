using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments;

public class PaymentModel
{
    [JsonProperty("amount")] [Required] public decimal Amount { get; set; }

    [JsonProperty("description")]
    [Required]
    public string Description { get; set; }

    [JsonProperty("currency")] [Required] public string Currency { get; set; }
}