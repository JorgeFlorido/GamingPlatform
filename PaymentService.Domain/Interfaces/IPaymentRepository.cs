using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Interfaces
{
  public interface IPaymentRepository
  {
    Task<Payment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Payment>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
    Task DeleteAsync(Guid id);
  }
}
