using MediatR;

namespace UserService.Application.Events
{
  public class UserCreatedEvent : INotification
  {
    public Guid UserId { get; }
    public UserCreatedEvent(Guid userId)
    {
      UserId = userId;
    }
  }
}
