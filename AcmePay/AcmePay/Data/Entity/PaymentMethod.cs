namespace AcmePay.Data.Entity;

public class PaymentMethod
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Field> Fields { get; set;}
}