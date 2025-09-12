namespace UserService.Application.Interfaces
{
  public interface IOutboxEventPublisher
  {
    Task PublishAsync<T>(T @event, string topic, CancellationToken cancellationToken = default) where T : class;
  }
}



