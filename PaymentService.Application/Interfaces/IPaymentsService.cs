using PaymentService.Application.DTOs;

namespace PaymentService.Application.Interfaces
{
  public interface IPaymentsService
  {
    Task<PaymentResult> MakePaymentAsync(Guid userId, Guid paymentId, Guid paymentProviderId, decimal amount, string currency, CancellationToken cancellationToken);
  }
}
