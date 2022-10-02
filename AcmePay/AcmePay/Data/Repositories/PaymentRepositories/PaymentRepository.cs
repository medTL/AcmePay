using AcmePay.Data.Entity;
using AcmePay.Models.Enums;
using AcmePay.Models.Payments;
using AcmePay.Models.Payments.Request;
using Microsoft.EntityFrameworkCore;

namespace AcmePay.Data.Repositories.PaymentRepositories;

public class PaymentRepository : IPaymentRepository

{
    private readonly AcmeContext _context;

    public PaymentRepository(AcmeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create payment
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Payment> CreatePaymentAsync(PaymentModel model, CancellationToken cancellationToken = default)
    {
        var payment = new Payment
        {
            Amount = model.Amount,
            Description = model.Description,
            Currency = model.Currency,
            Status = (int)PaymentStatus.Pending,
        };
        await _context.Payments.AddAsync(payment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return payment;
    }

    public async Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Payments.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    ///  Set payment method
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="paymentMethodId"></param>
    /// <param name="cancellationToken"></param>
    public async Task SetPaymentMethodAsync(Payment payment, Guid paymentMethodId,
        CancellationToken cancellationToken = default)
    {
        payment.PaymentMethodId = paymentMethodId;
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Update payment status
    /// </summary>
    /// <param name="payment"></param>
    /// <param name="cancellationToken"></param>
    public async Task UpdatePaymentStatus(Payment payment, CancellationToken cancellationToken = default)
    {
        payment.Status = (int)PaymentStatus.Paid;
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}