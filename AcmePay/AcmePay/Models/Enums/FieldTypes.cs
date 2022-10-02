using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AcmePay.Models.Enums;

public enum FieldTypes
{
    [EnumMember(Value = "text")] Text = 0,

    [EnumMember(Value = "date")] Date = 1,

    [EnumMember(Value = "number")] Number = 2,
}