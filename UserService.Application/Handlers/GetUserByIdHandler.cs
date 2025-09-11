using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Application.Requests;

namespace UserService.Application.Handlers
{
  internal class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, UserResponse>
  {
    private readonly IUsersService _usersService;
    public GetUserByIdHandler(IUsersService usersService)
    {
      _usersService = usersService;
    }
    public async Task<UserResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
      var user = await _usersService.GetUserByIdAsync(request.UserId);
      return user;
    }
  }
}
