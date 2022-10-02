using System.Runtime.Serialization;

namespace AcmePay.Models.Enums;

public enum AcmeError
{
    [EnumMember(Value = "INVALID_DATA")] 
    INVALID_DATA,

    [EnumMember(Value = "PAYMENT_NOT_FOUND")]
    PAYMENT_NOT_FOUND,

    [EnumMember(Value = "PAYMENT_METHOD_NOT_FOUND")]
    PAYMENT_METHOD_NOT_FOUND,
}