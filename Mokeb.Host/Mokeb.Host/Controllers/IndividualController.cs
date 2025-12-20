using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.ActivingPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingIndividualPrincipalInformation;
using Mokeb.Application.CommandHandler.AdminCommands.DeleteIndividual;
using Mokeb.Application.CommandHandler.IndividualCommands.IndividualPrincipalLogIn;
using Mokeb.Application.CommandHandler.IndividualCommands.IndividualPrincipalSignIn;
using Mokeb.Application.CommandHandler.PrincipalsLogOut;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingPrincipalInformation;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingIndividuals.LookingOnIndividuals;

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
        [HttpGet("{individualId}")]
        public async Task<IActionResult> GettingIndividualInformation([FromRoute] Guid individualId, CancellationToken ct)
        {
            var query = new GettingPrincipalInformationQuery();
            query.PrincipalId = individualId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Principal);
        }
        [HttpPut("{individualId}/ActivateOrDeactivatePrincipal")]
        public async Task<IActionResult> ActivateOrDeactivatePrincipal([FromRoute] Guid individualId, [FromBody] ActivingOrDeActivingPrincipalCommand command, CancellationToken ct)
        {
            command.PrincipalId = individualId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("درخواست با موفقیت انحام یافت");
            return BadRequest("درخواست انجام نشد");
        }
        [HttpGet]
        public async Task<IActionResult> GetIndividuals(CancellationToken ct)
        {
            var query = new LookingOnIndividualsQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        [HttpPut("{individualId}/ChangePrincipal")]
        public async Task<IActionResult> ChangingIndividualPrincipal([FromRoute] Guid individualId, [FromBody] ChangingIndividualPrincipalInformationCommand command, CancellationToken ct)
        {
            command.IndividualId = individualId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("شخص حقیقی تغییر کرد");
            return BadRequest("شخص حقیقی تغییر نکرد");
        }
        [HttpDelete("{individualId}")]
        public async Task<IActionResult> DeletingIndividual([FromRoute] Guid individualId, [FromBody] DeleteIndividualCommand command, CancellationToken ct)
        {
            command.IndividualId = individualId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("شخص با موفقیت حذف شد");
            return BadRequest("شخص حذف نشد");
        }
    }
}
