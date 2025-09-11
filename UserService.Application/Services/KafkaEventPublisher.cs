using Confluent.Kafka;
using System.Text.Json;
using UserService.Application.Interfaces;

namespace UserService.Application.Services
{
  internal class KafkaEventPublisher : IEventPublisher
  {
    private readonly IProducer<Null, string> _producer;

    public KafkaEventPublisher(ProducerConfig config)
    {
      _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task PublishAsync<T>(T @event, string topic, CancellationToken cancellationToken = default) where T : class
    {
      var message = JsonSerializer.Serialize(@event);
      await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message }, cancellationToken);
    }
  }
}
