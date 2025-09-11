namespace Shared.Contracts.Events
{
  public class UserCreatedEvent
  {
    public Guid UserId { get; }
    public string? Currency { get; }

    public UserCreatedEvent(Guid userId, string? currency)
    {
      UserId = userId;
      Currency = currency;
    }
  }
}
