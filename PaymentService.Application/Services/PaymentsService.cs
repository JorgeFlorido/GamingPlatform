using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.Services
{
  public class PaymentsService : IPaymentsService
  {
    private readonly IPaymentProviderStrategy _providerStrategy;

    public PaymentsService(IPaymentProviderStrategy providerStrategy)
    {
      _providerStrategy = providerStrategy;
    }

    public async Task<PaymentResult> MakePaymentAsync(Guid userId, Guid paymentId, Guid paymentProviderId, decimal amount, string currency, CancellationToken cancellationToken)
    {
      var provider = _providerStrategy.GetProvider(paymentProviderId);

      var payment = new Payment(paymentId, userId, amount, currency);

      return await provider.MakePaymentAsync(payment);
    }
  }
}
