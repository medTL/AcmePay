namespace AcmePay.Data.Entity;

public class Validator
{
    public Guid Id { get; set; }
    public bool Required { get; set; }

    public int? MaxLength { get; set; }

    public int? MinLength { get; set; }

    public string? Pattern { get; set; }
}