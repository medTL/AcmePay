using AcmePay.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AcmePay.Data.Repositories.PaymentMethodRepositories;

public class PaymentMethodRepository : IPaymentMethodRepository
{
    private readonly AcmeContext _context;

    public PaymentMethodRepository(AcmeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List payment methods
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<PaymentMethod>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PaymentMethods
            .Include(x => x.Fields)
            .ThenInclude(v => v.Validator)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Get payment method by id
    /// </summary>
    /// <param name="paymentMethodId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PaymentMethod?> GetByIdAsync(Guid paymentMethodId, CancellationToken cancellationToken = default)
    {
        return await _context.PaymentMethods.Where(x => x.Id == paymentMethodId)
            .Include(f => f.Fields)
            .ThenInclude(v => v.Validator)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Get payment method by name
    /// </summary>
    /// <param name="paymentMethodName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PaymentMethod?> GetByNameAsync(string paymentMethodName,
        CancellationToken cancellationToken = default)
    {
        return await _context.PaymentMethods.Where(x => x.Name.Trim().ToLower() == paymentMethodName.Trim().ToLower())
            .Include(f => f.Fields)
            .ThenInclude(v => v.Validator)
            .FirstOrDefaultAsync(cancellationToken);
    }
}