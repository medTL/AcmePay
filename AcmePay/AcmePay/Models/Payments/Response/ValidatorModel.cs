using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Response;

public class ValidatorModel
{
    [JsonProperty("id")] public Guid Id { get; set; }

    [JsonProperty("required")] public bool Required { get; set; }

    [JsonProperty("maxLength")] public int? MaxLength { get; set; }

    [JsonProperty("minLength")] public int? MinLength { get; set; }

    [JsonProperty("pattern")] public string? Pattern { get; set; }

    [JsonProperty("algorithmCheck")] public AlgoValidationNames? AlgorithmCheck { get; set; }
}