using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Entities
{
  public class Transaction
  {
    public Guid Id { get; private set; }
    public Guid WalletId { get; private set; }
    public Guid? PaymentId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public TransactionType Type { get; private set; }

    protected Transaction() { }

    public Transaction(Guid walletId, decimal amount, string currency, TransactionType type, Guid? paymentId = null)
    {
      Id = Guid.NewGuid();
      WalletId = walletId;
      Amount = amount;
      Currency = currency;
      Type = type;
      PaymentId = paymentId;
      CreatedAt = DateTime.UtcNow;
    }
  }
}
