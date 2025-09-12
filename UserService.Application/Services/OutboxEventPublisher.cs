using System.Text.Json;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services
{
  internal class OutboxEventPublisher : IOutboxEventPublisher
  {
    private readonly IOutboxMessageRepository _outboxMessageRepository;

    public OutboxEventPublisher(IOutboxMessageRepository outboxMessageRepository)
    {
      _outboxMessageRepository = outboxMessageRepository;
    }

    public async Task PublishAsync<T>(T @event, string topic, CancellationToken cancellationToken = default) where T : class
    {
      var outboxMessage = new OutboxMessage
      {
        Id = Guid.NewGuid(),
        Type = typeof(T).Name,
        Payload = JsonSerializer.Serialize(@event),
        Topic = topic,
        CreatedAt = DateTime.UtcNow
      };

      await _outboxMessageRepository.AddAsync(outboxMessage);
    }
  }
}
