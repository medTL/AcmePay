using AcmePay.Data.Entity;
using AcmePay.Models.Enums;
using AcmePay.Models.Payments;
using AcmePay.Models.Payments.Response;

namespace AcmePay.BL.Renders;

/// <summary>
/// A mapper from entity to requests response models
/// </summary>
public class PaymentRender : IPaymentRender
{
    /// <summary>
    /// Get payment details model
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="paymentMethods"></param>
    /// <returns></returns>
    public PaymentDetailsModel GetPaymentDetails(Payment payment, IEnumerable<PaymentMethod> paymentMethods)
    {
        return new PaymentDetailsModel
        {
            Amount = payment.Amount,
            Currency = payment.Currency,
            Id = payment.Id,
            PaymentMethods = paymentMethods.Select(GetPaymentMethod),
        };
    }

    /// <summary>
    /// Get payment method model
    /// </summary>
    /// <param name="paymentMethod"></param>
    /// <returns></returns>
    public PaymentMethodModel GetPaymentMethod(PaymentMethod paymentMethod)
    {
        return new PaymentMethodModel
        {
            Id = paymentMethod.Id,
            Name = paymentMethod.Name,
            Fields = paymentMethod.Fields.Select(GetPaymentField)
        };
    }

    /// <summary>
    /// Get payment field model
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    public FieldModel GetPaymentField(Field field)
    {
        return new FieldModel
        {
            Id = field.Id,
            value = field.Value,
            Label = field.Label,
            Name = field.Name,
            Type = (FieldTypes)field.Type,
            PlaceHolder = field.PlaceHolder ?? "",
            Validator = GetPaymentValidator(field.Validator),
        };
    }

    /// <summary>
    /// Get payment validator model
    /// </summary>
    /// <param name="validator"></param>
    /// <returns></returns>
    public ValidatorModel GetPaymentValidator(Validator validator)
    {
        return new ValidatorModel
        {
            Id = validator.Id,
            Required = validator.Required,
            MaxLength = validator.MaxLength,
            MinLength = validator.MinLength,
            Pattern = validator.Pattern,
            AlgorithmCheck = (AlgoValidationNames)validator.AlgorithmCheck
            
        };
    }
}