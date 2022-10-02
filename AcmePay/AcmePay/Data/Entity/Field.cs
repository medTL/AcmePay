namespace AcmePay.Data.Entity;

public class Field
{
    public Guid Id { get; set; }

    public Guid? PaymentMethodId { get; set; }

    public Guid? ValidatorId { get; set; }

    public string Name { get; set; }

    public string Label { get; set; }

    public string? Value { get; set; }
    
    public string? PlaceHolder { get; set; }

    public int Type { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; }

    public virtual Validator Validator { get; set; }
}