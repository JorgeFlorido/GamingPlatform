namespace UserService.Application.Interfaces
{
  public interface IEventPublisher
  {
    Task PublishAsync<T>(T @event, string topic, CancellationToken cancellationToken = default) where T : class;
  }
}
