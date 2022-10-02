using System.Text.Json.Serialization;
using AcmePay.Models.Enums;

namespace AcmePay.Models.Payments;

public class FieldModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("label")] public string Label { get; set; }

    [JsonPropertyName("value")] public string value { get; set; }

    [JsonPropertyName("type")] public FieldTypes Type { get; set; }
    
    [JsonPropertyName("placeHolder")]
    public string? PlaceHolder { get; set; }

    [JsonPropertyName("validator")] public ValidatorModel Validator { get; set; }
}