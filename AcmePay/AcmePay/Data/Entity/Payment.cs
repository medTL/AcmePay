namespace AcmePay.Data.Entity;

public class Payment
{
    public Guid Id { get; set; }

    public Guid PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; }

    public int Status { get; set; }
    
    public string Currency { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }
}