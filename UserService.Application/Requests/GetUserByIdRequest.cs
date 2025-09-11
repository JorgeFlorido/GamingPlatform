using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Requests
{
  public record GetUserByIdRequest : IRequest<UserResponse>
  {
    public Guid UserId { get; init; }

    public GetUserByIdRequest(Guid userId)
    {
      UserId = userId;
    }
  }
}
