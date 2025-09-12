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
      return await Task.FromResult(_context.OutboxMessages.Where(m => !m.Processed).ToList());
    }

    public async Task MarkAsProcessedAsync(Guid messageId)
    {
      var message = await _context.OutboxMessages.FindAsync(messageId);
      if (message != null)
      {
        message.Processed = true;
        await _context.SaveChangesAsync();
      }
    }
  }
}
