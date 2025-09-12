using MediatR;
using Shared.Contracts.Events;
using UserService.Application.Commands;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Handlers
{
  internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserResponse>
  {
    private readonly IUsersService _userRegistrationService;
    private readonly IOutboxEventPublisher _eventPublisher;

    public RegisterUserHandler(IUsersService userRegistrationService, IOutboxEventPublisher eventPublisher)
    {
      _userRegistrationService = userRegistrationService;
      _eventPublisher = eventPublisher;
    }

    public async Task<UserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRegistrationService.RegisterAsync(request.Username, request.Email, request.Password);

      var userCreatedEvent = new UserCreatedEvent(user.Id, "USD");
      await _eventPublisher.PublishAsync(userCreatedEvent, "user-created", cancellationToken);

      return new UserResponse(user.Id, user.Username, user.Email);
    }
  }
}
