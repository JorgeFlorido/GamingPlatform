using PaymentService.Application.DTOs;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.Interfaces
{
  public interface IPaymentProvider
  {
    Task<PaymentResult> MakePaymentAsync(Payment payment);
    string ProviderName { get; }
    Guid Id { get; }
  }
}
