using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Entities
{
  public class Transaction
  {
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
  }
}
