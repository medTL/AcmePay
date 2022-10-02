using System.ComponentModel.DataAnnotations;
using AcmePay.Models.Validator;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Request;

public class VisaPaymentModel
{
    [JsonProperty("cardNumber")]
    [Required]
    [LuhnValidator]
    public string CardNumber { get; set; }
    
    [Required]
    [JsonProperty("expirationDate")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$")]
    public string ExpirationDate { get; set; }

    [JsonProperty("cvc")]
    [Required]
    public int Cvc { get; set; }

    [JsonProperty("cardHolder")]
    [Required]
    [MaxLength(50)]
    [MinLength(15)]
    public string CardHolder { get; set; }
}