using System.Runtime.Serialization;
using AcmePay.Models.Enums;
using Newtonsoft.Json;

namespace AcmePay.Models.Api.generic;

public class ApiResponse<T>
{
  
    
    [DataMember(Name = "message", EmitDefaultValue = false)]
    [JsonProperty("message")]
    public MessageEnum? Message { get; set; }
    
    public ApiResponse(T data = default,
        MessageEnum? message = default, IDictionary<string, string[]> description = default)
    {
        Data = data;
        Message = message;
        Description = description;
    }
    
    [DataMember(Name = "data", EmitDefaultValue = false)]
    [JsonProperty("data")]
    public T Data { get; set; }
    
    [DataMember(Name = "description", EmitDefaultValue = false)]
    [JsonProperty("description")]
    public IDictionary<string, string[]> Description;

}