namespace PaymentService.Domain.Entities
{
  public class Wallet
  {
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Balance { get; private set; }

    private readonly List<Transaction> _transactions = [];
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    protected Wallet() { }

    public Wallet(Guid userId)
    {
      Id = Guid.NewGuid();
      UserId = userId;
      Balance = 0m;
    }

    public void AddTransaction(Transaction transaction)
    {
      _transactions.Add(transaction);
      Balance += transaction.Amount;
    }
  }

}
