using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Enums;

namespace PaymentService.Application.Providers
{
  public class MockProviderB : IPaymentProvider
  {
    public Guid Id { get; } = Guid.NewGuid();
    public string ProviderName { get; } = "MockProviderB";

    public Task<PaymentResult> MakePaymentAsync(Payment payment)
    {
      var result = new PaymentResult
      {
        PaymentId = payment.Id,
        TransactionId = Guid.NewGuid(),
        Status = PaymentStatus.Pending,
        Message = "Payment processed by MockProviderB"
      };

      return Task.FromResult(result);
    }
  }
}
