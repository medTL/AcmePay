using AcmePay.Data.Entity;

namespace AcmePay.Data.Repositories.PaymentMethodRepositories;

public interface IPaymentMethodRepository
{
    /// <summary>
    /// List payment methods
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<PaymentMethod>> ListAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get payment method by id
    /// </summary>
    /// <param name="paymentMethodId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaymentMethod?> GetByIdAsync(Guid paymentMethodId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get payment method by name
    /// </summary>
    /// <param name="paymentMethodName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaymentMethod?> GetByNameAsync(string paymentMethodName, CancellationToken cancellationToken = default);
}