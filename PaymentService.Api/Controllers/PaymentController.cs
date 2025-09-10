using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.Commands;

namespace PaymentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("make-payment")]
        public async Task<IActionResult> MakePayment([FromBody] MakePaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}