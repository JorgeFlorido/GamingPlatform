using MediatR;
using PaymentService.Application.DTOs;

namespace PaymentService.Application.Commands
{
  public record MakePaymentCommand : IRequest<PaymentResult>
  {
    public Guid UserId { get; init; }
    public Guid PaymentId { get; init; }
    public Guid PaymentProviderId { get; init; }
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;
  }
}
