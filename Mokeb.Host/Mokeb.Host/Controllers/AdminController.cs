using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.AdminLogIn;
using Mokeb.Application.CommandHandler.PrincipalsLogOut;
using Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate;
using Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate;
using Mokeb.Application.QueryHandler.AdminQueries.GettingCaravanInformation;
using Mokeb.Application.QueryHandler.AdminQueries.GettingOutGoingAcceptedCaravansRequestsByDate;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogInAdmin([FromBody] AdminLogInCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (!string.IsNullOrEmpty(result.JwsCode))
                return Ok(result.JwsCode);
            return BadRequest("You are Not LoggedIn");
        }
        [HttpPost("{adminId}/LogOut")]
        public async Task<IActionResult> Logout([FromRoute] Guid adminId, [FromBody] PrincipalsLogOutCommand command, CancellationToken ct)
        {
            command.Id = adminId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("You are logged out successfully");
            return BadRequest("You are not logged out");
        }
        [HttpGet("/GettingRequestsAtADay/{date}")]
        public async Task<IActionResult> GettingRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingAcceptedRequestsByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }
        [HttpGet("/GettingCaravanRequestsAtADay/{date}")]
        public async Task<IActionResult> GettingCaravanRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingAcceptedCaravansRequestsByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }
        [HttpGet("/GettingOutGoingOrAcceptedRequestsAtADay/{date}")]
        public async Task<IActionResult> GettingOutGoingOrAcceptedRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingOutGoingOrAcceptedRequestsByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }
        [HttpGet("/GettingPrincipalInformation/{principalId}")]
        public async Task<IActionResult> GettingCaravanRequests([FromRoute] Guid principalId, CancellationToken ct)
        {
            var query = new GettingPrincipalInformationQuery();
            query.PrincipalId = principalId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Principal);
        }
    }
}
