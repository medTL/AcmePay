using AcmePay.Data.Entity;
using AcmePay.Models.Payments;
using AcmePay.Models.Payments.Request;

namespace AcmePay.Data.Repositories.PaymentRepositories;

public interface IPaymentRepository
{
    /// <summary>
    /// Create payment
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Payment> CreatePaymentAsync(PaymentModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get payment by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set payment method
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="paymentMethodId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetPaymentMethodAsync(Payment payment, Guid paymentMethodId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Update payment status
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdatePaymentStatus(Payment payment, CancellationToken cancellationToken = default);
}