using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Request;

public class SepaPaymentModel
{
    [JsonProperty("iban")]
    [Required]
    [MinLength(15)]
    [MaxLength(32)]
    public string Iban { get; set; }
    
    [JsonProperty("bic")]
    [Required]
    [MinLength(8)]
    public string Bic { get; set; }

    [JsonProperty("holderName")]
    [Required]
    [MinLength(15)]
    [MaxLength(50)]
    public string HolderName { get; set; }
}