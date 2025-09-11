using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;

namespace PaymentService.Application.Services
{
  internal class WalletService : IWalletService
  {
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
      _walletRepository = walletRepository;
    }

    public async Task<Guid> CreateWalletAsync(Guid userId, string? currency)
    {
      var existingWallet = await _walletRepository.GetByUserIdAsync(userId);
      if (existingWallet != null)
      {
        throw new InvalidOperationException("Wallet already exists for this user.");
      }
      var wallet = new Wallet(userId, currency);
      await _walletRepository.AddAsync(wallet);
      return wallet.Id;
    }

    public Task DeleteWalletAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task DepositAsync(Guid userId, decimal amount)
    {
      throw new NotImplementedException();
    }

    public Task<decimal> GetBalanceAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task TransferAsync(Guid fromUserId, Guid toUserId, decimal amount)
    {
      throw new NotImplementedException();
    }

    public Task WithdrawAsync(Guid userId, decimal amount)
    {
      throw new NotImplementedException();
    }
  }
}
