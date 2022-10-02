using System.Runtime.Serialization;
using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Api;

public class ApiResponse
{
    public ApiResponse(AcmeError? error = default,
        MessageEnum? message = default, IDictionary<string, string[]> description = default)
    {
        Error = error;
        Message = message;
        Description = description;
    }
    
    [DataMember(Name = "error", EmitDefaultValue = false)]
    [JsonProperty("error")]
    public AcmeError? Error { get; set; }

    [DataMember(Name = "message", EmitDefaultValue = false)]
    [JsonProperty("message")]
    public MessageEnum? Message { get; set; }
    
    [DataMember(Name = "description", EmitDefaultValue = false)] [JsonProperty("description")]
    public IDictionary<string, string[]> Description;
}