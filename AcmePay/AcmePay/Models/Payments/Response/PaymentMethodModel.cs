namespace AcmePay.Models.Payments.Response;

public class PaymentMethodModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<FieldModel> Fields { get; set; }
}