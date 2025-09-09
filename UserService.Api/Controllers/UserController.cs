using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserRegistrationService _userRegistrationService;

    public UserController(IUserRegistrationService userRegistrationService)
    {
      _userRegistrationService = userRegistrationService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register(RegisterUserRequest request)
    {
      var user = await _userRegistrationService.RegisterUserAsync(request.Username, request.Email, request.Password);
      return Ok(user);
    }
  }
}
