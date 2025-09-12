using UserService.Application.Interfaces;
using UserService.Domain.Interfaces;

namespace UserService.Api.HostedServices
{
  public class OutboxPublisherHostedService : BackgroundService
  {
    private readonly IServiceScopeFactory _scopeFactory;

    public OutboxPublisherHostedService(IServiceScopeFactory scopeFactory)
    {
      _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
      try
      {
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
          using var scope = _scopeFactory.CreateScope();
          var outboxRepository = scope.ServiceProvider.GetRequiredService<IOutboxMessageRepository>();
          var eventPublisher = scope.ServiceProvider.GetRequiredService<IKafkaEventPublisher>();

          var messages = await outboxRepository.GetPendingMessagesAsync();
          foreach (var msg in messages)
          {
            await eventPublisher.PublishAsync(msg.Payload, msg.Topic, stoppingToken);
            await outboxRepository.MarkAsProcessedAsync(msg.Id);
          }
        }
      }
      catch (OperationCanceledException)
      {
        // graceful shutdown
      }
    }
  }

}
