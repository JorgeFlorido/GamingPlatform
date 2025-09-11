using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Commands
{
  public record RegisterUserCommand : IRequest<UserResponse>
  {
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
  }
}
