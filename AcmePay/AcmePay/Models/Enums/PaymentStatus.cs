using System.Runtime.Serialization;

namespace AcmePay.Models.Enums;

public enum PaymentStatus
{
    [EnumMember(Value = "PENDING")] Pending = 0,

    [EnumMember(Value = "PAID")] Paid = 1
}