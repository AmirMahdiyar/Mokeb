using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.CaravanPrincipalLogIn;
using Mokeb.Application.CommandHandler.CaravanPrincipalSignIn;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaravanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CaravanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> AddCaravan([FromBody] CaravanPrincipalSignInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Caravan Added Successfully");
            return BadRequest("Something Went Wrong");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LogInCaravan([FromBody] CaravanPrincipalLogInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (!string.IsNullOrEmpty(result.JwsCode))
                return Ok(result.JwsCode);
            return BadRequest("You are Not LoggedIn");
        }
    }
}
