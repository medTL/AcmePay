using System.Text.Json.Serialization;

namespace AcmePay.Models.Payments;

public class ValidatorModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("required")] public bool Required { get; set; }

    [JsonPropertyName("maxLength")] public int? MaxLength { get; set; }

    [JsonPropertyName("minLength")] public int? MinLength { get; set; }

    [JsonPropertyName("pattern")] public string? Pattern { get; set; }
}