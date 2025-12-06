using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.IndividualPrincipalSignIn;

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

        [HttpPost]
        public async Task<IActionResult> AddIndividual([FromBody] IndividualPrincipalSignInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Caravan Added Successfully");
            return BadRequest("Something Went Wrong");
        }
    }
}
