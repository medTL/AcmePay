using System.Text.Json.Serialization;
using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Payments.Response;

public class FieldModel
{
    [JsonProperty("id")] public Guid Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("label")] public string Label { get; set; }

    [JsonProperty("value")] public string value { get; set; }

    [JsonProperty("type")] public FieldTypes Type { get; set; }
    
    [JsonProperty("placeHolder")]
    public string? PlaceHolder { get; set; }

    [JsonProperty("validator")] public ValidatorModel Validator { get; set; }
}