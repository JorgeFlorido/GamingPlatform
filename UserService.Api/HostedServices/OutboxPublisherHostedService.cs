using UserService.Application.Interfaces;
using UserService.Domain.Interfaces;

namespace UserService.Api.HostedServices
{
  public class OutboxPublisherHostedService : BackgroundService
  {
    private readonly IOutboxMessageRepository _outboxRepository;
    private readonly IKafkaEventPublisher _eventPublisher;

    public OutboxPublisherHostedService(
        IOutboxMessageRepository outboxRepository,
        IKafkaEventPublisher eventPublisher)
    {
      _outboxRepository = outboxRepository;
      _eventPublisher = eventPublisher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        var messages = await _outboxRepository.GetPendingMessagesAsync();

        foreach (var msg in messages)
        {
          await _eventPublisher.PublishAsync(msg.Payload, msg.Topic, stoppingToken);
          await _outboxRepository.MarkAsProcessedAsync(msg.Id);
        }

        await Task.Delay(1000, stoppingToken);
      }
    }
  }

}
