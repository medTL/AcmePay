using System.Runtime.Serialization;

namespace AcmePay.Models.Enums;

public enum MessageEnum
{
    [EnumMember(Value = "OK")]
    Ok = 1,

    [EnumMember(Value = "PAYMENT_CREATED")]
    PaymentCreated = 2,
    
    [EnumMember(Value = "PAYMENT_PAID")]
    PaymentPaid = 3,
}