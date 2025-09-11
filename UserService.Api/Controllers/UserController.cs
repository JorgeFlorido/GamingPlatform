using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.Requests;

namespace UserService.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
      var result = await _mediator.Send(command);
      return Ok(result);
    }

    [HttpGet("get-users")]
    public async Task<IActionResult> GetUsers()
    {
      var result = await _mediator.Send(new GetUsersRequest());
      return Ok(result);
    }

    [HttpGet("get-user-by-id/{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
      var request = new GetUserByIdRequest(id);
      var result = await _mediator.Send(request);
      return Ok(result);
    }
  }
}
