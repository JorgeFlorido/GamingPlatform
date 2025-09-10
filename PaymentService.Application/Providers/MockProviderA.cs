using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Enums;

namespace PaymentService.Application.Providers
{
  public class MockProviderA : IPaymentProvider
  {
    public Guid Id { get; } = Guid.NewGuid();
    public string ProviderName { get; } = "MockProviderA";

    public Task<PaymentResult> MakePaymentAsync(Payment payment)
    {
      var result = new PaymentResult
      {
        Status = PaymentStatus.Pending,
        Message = "Payment processed by MockProviderA"
      };

      return Task.FromResult(result);
    }
  }
}
