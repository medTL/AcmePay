using Microsoft.EntityFrameworkCore;

namespace AcmePay.Data.Entity;

public class AcmeContext : DbContext
{
    public AcmeContext()
    {
    }

    public AcmeContext(DbContextOptions<AcmeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Validator> Validators { get; set; }
}