using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.IndividualPrincipalLogIn;
using Mokeb.Application.CommandHandler.IndividualPrincipalSignIn;
using Mokeb.Application.CommandHandler.PrincipalsLogOut;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndividualController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndividualController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> AddIndividual([FromBody] IndividualPrincipalSignInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Individual Added Successfully");
            return BadRequest("Something Went Wrong");
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInIndividual([FromBody] IndividualPrincipalLogInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (!string.IsNullOrEmpty(result.JwsCode))
                return Ok(result.JwsCode);
            return BadRequest("You are Not LoggedIn");
        }
        [HttpPost("{individualId}/LogOut")]
        public async Task<IActionResult> Logout([FromRoute] Guid individualId, [FromBody] PrincipalsLogOutCommand command, CancellationToken ct)
        {
            command.Id = individualId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("You are logged out successfully");
            return BadRequest("You are not logged out");
        }
    }
}
