namespace AcmePay.Models.Payments;

public class PaymentMethodModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<FieldModel> Fields { get; set; }
}