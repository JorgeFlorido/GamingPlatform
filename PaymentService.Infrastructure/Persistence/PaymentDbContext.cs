using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure.Persistence
{
  public class PaymentDbContext : DbContext
  {
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
    }

    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentProvider> PaymentProviders { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
  }
}
