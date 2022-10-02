using System.Runtime.Serialization;

namespace AcmePay.Models.Enums;

public enum AlgoValidationNames
{
    [EnumMember(Value = "NO_ALGO")] NoAlgo = 0,
    [EnumMember(Value = "LUHN")] Luhn = 1,
}