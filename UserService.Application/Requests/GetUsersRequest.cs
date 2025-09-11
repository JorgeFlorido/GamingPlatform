using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Requests
{
  public record GetUsersRequest : IRequest<List<UserResponse>>
  {
  }
}
