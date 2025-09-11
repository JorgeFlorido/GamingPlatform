namespace PaymentService.Domain.Interfaces
{
  public interface IWalletRepository
  {
    Task<Entities.Wallet?> GetByIdAsync(Guid id);
    Task<Entities.Wallet?> GetByUserIdAsync(Guid userId);
    Task AddAsync(Entities.Wallet wallet);
    Task UpdateAsync(Entities.Wallet wallet);
    Task DeleteAsync(Guid id);
  }
}
