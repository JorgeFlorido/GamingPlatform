using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Application.Requests;

namespace UserService.Application.Handlers
{
  internal class GetUsersHandler : IRequestHandler<GetUsersRequest, List<UserResponse>>
  {
    private readonly IUsersService _usersService;

    public GetUsersHandler(IUsersService usersService)
    {
      _usersService = usersService;
    }

    public async Task<List<UserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
      var users = await _usersService.GetUsersAsync();
      return users;
    }
  }
}
