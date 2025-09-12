using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
  public interface IOutboxMessageRepository
  {
    Task AddAsync(OutboxMessage message);
    Task<IEnumerable<OutboxMessage>> GetPendingMessagesAsync();
    Task MarkAsProcessedAsync(Guid messageId);
  }
}
