using System.ComponentModel.DataAnnotations;

namespace AcmePay.Models.Validator;

public class LuhnValidator : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return false;
        }

        int nDigits = value.ToString()!.Length;

        int nSum = 0;
        bool isSecond = false;
        for (int i = nDigits - 1; i >= 0; i--)
        {
            int d = value.ToString()![i] - '0';

            if (isSecond == true)
                d = d * 2;

            nSum += d / 10;
            nSum += d % 10;

            isSecond = !isSecond;
        }

        return (nSum % 10 == 0);
    }
}