using MediatR;
using UserService.Application.Commands;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Handlers
{
  internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserResponse>
  {
    private readonly IUsersService _userRegistrationService;

    public RegisterUserHandler(IUsersService userRegistrationService)
    {
      _userRegistrationService = userRegistrationService;
    }

    public async Task<UserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRegistrationService.RegisterAsync(request.Username, request.Email, request.Password);
      return new UserResponse(user.Id, user.Username, user.Email);
    }
  }
}
