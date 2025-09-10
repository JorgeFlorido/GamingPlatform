using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Entities
{
  public class Payment
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Currency { get; set; } = string.Empty;
    public Guid ProviderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public PaymentStatus Status { get; set; }

    public Payment(Guid id, Guid userId, decimal amount, string currency)
    {
      Id = id;
      UserId = userId;
      Amount = amount;
      Currency = currency;
    }
  }
}
