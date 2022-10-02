using System.Text.Json.Serialization;
using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments;

public class ValidatorModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("required")] public bool Required { get; set; }

    [JsonPropertyName("maxLength")] public int? MaxLength { get; set; }

    [JsonPropertyName("minLength")] public int? MinLength { get; set; }

    [JsonPropertyName("pattern")] public string? Pattern { get; set; }

    [JsonProperty("algorithmCheck")] public AlgoValidationNames? AlgorithmCheck { get; set; }
}