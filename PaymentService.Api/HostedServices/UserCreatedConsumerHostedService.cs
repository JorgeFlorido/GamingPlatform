using Confluent.Kafka;
using MediatR;
using PaymentService.Application.Commands;
using Shared.Contracts.Events;
using System.Text.Json;

namespace PaymentService.Api.HostedServices
{
  public class UserCreatedConsumerHostedService : BackgroundService
  {
    private readonly string _topic = "user-created";
    private readonly string _bootstrapServers;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<UserCreatedConsumerHostedService> _logger;

    public UserCreatedConsumerHostedService(
      IConfiguration configuration, 
      ILogger<UserCreatedConsumerHostedService> logger,
      IServiceScopeFactory scopeFactory)
    {
      _bootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServers") ?? throw new ArgumentNullException("Kafka:BootstrapServers");
      _logger = logger;
      _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
      using var scope = _scopeFactory.CreateScope();
      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      var config = new ConsumerConfig
      {
        BootstrapServers = _bootstrapServers,
        GroupId = "payment-service-group",
        AutoOffsetReset = AutoOffsetReset.Earliest
      };

      using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
      consumer.Subscribe(_topic);

      try
      {
        while (!cancellationToken.IsCancellationRequested)
        {
          var cr = consumer.Consume(cancellationToken);

          _logger.LogInformation($"Received message '{cr.Message.Value}' at: '{cr.TopicPartitionOffset}'.");

          var userCreatedEvent = JsonSerializer.Deserialize<UserCreatedEvent>(cr.Message.Value);

          if (userCreatedEvent != null)
          {
            await mediator.Send(new CreateWalletCommand(userCreatedEvent.UserId, userCreatedEvent.Currency), cancellationToken);
          }
        }
      }
      catch (OperationCanceledException)
      {
        consumer.Close();
      }
    }

  }
}
