using AcmePay.Data.Entity;
using AcmePay.Models.Payments;
using AcmePay.Models.Payments.Response;

namespace AcmePay.BL.Renders;

/// <summary>
/// A mapper from entity to requests response models
/// </summary>
public interface IPaymentRender
{
    /// <summary>
    /// Get payment details model
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="paymentMethods"></param>
    /// <returns></returns>
    PaymentDetailsModel GetPaymentDetails(Payment payment, IEnumerable<PaymentMethod> paymentMethods);

    /// <summary>
    /// Get payment method model
    /// </summary>
    /// <param name="paymentMethod"></param>
    /// <returns></returns>
    PaymentMethodModel GetPaymentMethod(PaymentMethod paymentMethod);

    /// <summary>
    /// Get payment field model
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    FieldModel GetPaymentField(Field field);

    /// <summary>
    /// Get payment validator model
    /// </summary>
    /// <param name="validator"></param>
    /// <returns></returns>
    ValidatorModel GetPaymentValidator(Validator validator);
}