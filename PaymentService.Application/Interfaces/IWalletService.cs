using PaymentService.Domain.Entities;

namespace PaymentService.Application.Interfaces
{
  public interface IWalletService
  {
    Task<decimal> GetBalanceAsync(Guid userId);
    Task DepositAsync(Guid userId, decimal amount);
    Task WithdrawAsync(Guid userId, decimal amount);
    Task TransferAsync(Guid fromUserId, Guid toUserId, decimal amount);
    Task<Guid> CreateWalletAsync(Guid userId, string? currency);
    Task DeleteWalletAsync(Guid userId);
    Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(Guid userId);
  }
}
