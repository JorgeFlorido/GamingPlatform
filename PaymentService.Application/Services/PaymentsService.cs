using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.Services
{
  public class PaymentsService : IPaymentsService
  {
    private readonly IEnumerable<IPaymentProvider> _providers;

    public PaymentsService(IEnumerable<IPaymentProvider> providers)
    {
      _providers = providers;
    }

    public async Task<PaymentResult> MakePaymentAsync(Guid userId, Guid paymentId, Guid paymentProviderId, decimal amount, string currency, CancellationToken cancellationToken)
    {
      IPaymentProvider provider = _providers.FirstOrDefault(p => p.Id == paymentProviderId)
                                  ?? _providers.First();

      var payment = new Payment(paymentId, userId, amount, currency);

      return await provider.MakePaymentAsync(payment);
    }
  }
}
