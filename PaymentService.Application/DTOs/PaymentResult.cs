using PaymentService.Domain.Enums;

namespace PaymentService.Application.DTOs
{
  public record PaymentResult
  {
    public Guid PaymentId { get; init; }
    public Guid TransactionId { get; init; }
    public PaymentStatus Status { get; init; }
    public string Message { get; init; } = string.Empty;
  }
}
