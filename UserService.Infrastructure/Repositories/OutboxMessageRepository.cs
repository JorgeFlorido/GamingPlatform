using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure.Repositories
{
  public class OutboxMessageRepository : IOutboxMessageRepository
  {
    private readonly UserDbContext _context;

    public OutboxMessageRepository(UserDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(OutboxMessage message)
    {
      await _context.OutboxMessages.AddAsync(message);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OutboxMessage>> GetPendingMessagesAsync()
    {
      return await _context.OutboxMessages
        .AsNoTracking()
        .Where(m => !m.Processed)
        .OrderBy(m => m.CreatedAt)
        .ToListAsync();
    }

    public async Task MarkAsProcessedAsync(Guid messageId)
    {
      var message = await _context.OutboxMessages.FindAsync(messageId);
      if (message != null)
      {
        message.Processed = true;
        message.ProcessedOn = DateTime.UtcNow;
        await _context.SaveChangesAsync();
      }
    }
  }
}
