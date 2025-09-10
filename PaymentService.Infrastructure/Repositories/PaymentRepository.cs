using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Persistence;

namespace PaymentService.Infrastructure.Repositories
{
  public class PaymentRepository : IPaymentRepository
  {
    private readonly PaymentDbContext _context;

    public PaymentRepository(PaymentDbContext context)
    {
      _context = context;
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
      return await _context.Payments
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(Guid userId)
    {
      return await _context.Payments
        .Where(p => p.UserId == userId)
        .ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
      _context.Payments.Add(payment);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
      _context.Payments.Update(payment);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var payment = await _context.Payments.FindAsync(id);
      if (payment != null)
      {
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
      }
    }
  }
}
