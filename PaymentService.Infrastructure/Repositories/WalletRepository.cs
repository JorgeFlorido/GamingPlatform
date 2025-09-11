using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Persistence;

namespace PaymentService.Infrastructure.Repositories
{
  internal class WalletRepository : IWalletRepository
  {
    private readonly WalletDbContext _context;

    public WalletRepository(WalletDbContext context)
    {
      _context = context;
    }

    public async Task<Wallet?> GetByIdAsync(Guid id)
    {
      return await _context.Wallets.FindAsync(id);
    }

    public async Task<Wallet?> GetByUserIdAsync(Guid userId)
    {
      return await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
    }

    public async Task AddAsync(Wallet wallet)
    {
      await _context.Wallets.AddAsync(wallet);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
      _context.Wallets.Update(wallet);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var wallet = await GetByIdAsync(id);
      if (wallet != null)
      {
        _context.Wallets.Remove(wallet);
        await _context.SaveChangesAsync();
      }
    }
  }
}
