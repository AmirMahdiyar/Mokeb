using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.ActivingPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingCaravansPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.DeleteCaravan;
using Mokeb.Application.CommandHandler.CaravanCommands.AddPilgrim;
using Mokeb.Application.CommandHandler.CaravanCommands.CaravanPrincipalLogIn;
using Mokeb.Application.CommandHandler.CaravanCommands.CaravanPrincipalSignIn;
using Mokeb.Application.CommandHandler.CaravanCommands.CaravanSendsRequest;
using Mokeb.Application.CommandHandler.CaravanCommands.RemovePilgrim;
using Mokeb.Application.CommandHandler.PrincipalsLogOut;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingPrincipalInformation;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.LookingOnCaravans;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.SearchInCaravans;
using Mokeb.Application.QueryHandler.CaravanQueries.CaravanPilgrims;
using Mokeb.Application.QueryHandler.CaravanQueries.CaravanRequests;
using Mokeb.Application.QueryHandler.CaravanQueries.CaravanRequestsByDate;

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
        [HttpPost("{caravanId}/LogOut")]
        public async Task<IActionResult> Logout([FromRoute] Guid caravanId, [FromBody] PrincipalsLogOutCommand command, CancellationToken ct)
        {
            command.Id = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("You are logged out successfully");
            return BadRequest("You are not logged out");
        }
        [HttpGet("{caravanId}")]
        public async Task<IActionResult> GettingCaravanInformation([FromRoute] Guid caravanId, CancellationToken ct)
        {
            var query = new GettingPrincipalInformationQuery();
            query.PrincipalId = caravanId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Principal);
        }
        [HttpGet]
        public async Task<IActionResult> GetCaravans(CancellationToken ct)
        {
            var query = new LookingOnCaravansQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        [HttpDelete("{caravanId}")]
        public async Task<IActionResult> DeletingCaravan([FromRoute] Guid caravanId, [FromBody] DeleteCaravanCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("کاروان با موفقیت حذف شد");
            return BadRequest("کاروان حذف نشد");
        }
        [HttpPut("{caravanId}/ChangePrincipal")]
        public async Task<IActionResult> ChangingCaravansPrincipal([FromRoute] Guid caravanId, [FromBody] ChangingCaravansPrincipalCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok(" مدیرکاروان با موفقیت تغییر کرد");
            return BadRequest("مدیر کاروان تغییر نکرد");
        }
        [HttpPut("{caravanId}/ActivateOrDeactivatePrincipal")]
        public async Task<IActionResult> ActivateOrDeactivatePrincipal([FromRoute] Guid caravanId, [FromBody] ActivingOrDeActivingPrincipalCommand command, CancellationToken ct)
        {
            command.PrincipalId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("درخواست با موفقیت انحام یافت");
            return BadRequest("درخواست انجام نشد");
        }
        [HttpPost("Search")]
        public async Task<IActionResult> SearchInCaravans([FromBody] SearchInCaravansQuery query, CancellationToken ct)
        {
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.CaravanPrincipals);
        }
        [HttpPost("{caravanId}/SendRequest")]
        public async Task<IActionResult> SendRequest([FromRoute] Guid caravanId, CaravanSendsRequestCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("درخواست با موفقیت ارسال شد");
            return BadRequest("درخواست ارسال نشد !");
        }
        [HttpGet("{caravanId}/Requests")]
        public async Task<IActionResult> GetCaravanRequests([FromRoute] Guid caravanId, CancellationToken ct)
        {
            var query = new CaravanRequestsQuery();
            query.CaravanId = caravanId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Requests);
        }
        [HttpGet("{caravanId}/Requests/Search")]
        public async Task<IActionResult> GetCaravanRequestsAtDate([FromRoute] Guid caravanId, [FromQuery] DateOnly date, CancellationToken ct)
        {
            var query = new CaravanRequestsByDateQuery();
            query.CaravanId = caravanId;
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Requests);
        }
        [HttpPost("{caravanId}/Pilgrims")]
        public async Task<IActionResult> AddPilgrim([FromRoute] Guid caravanId, [FromBody] AddPilgrimCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("زاعر با موفقیت اضافه شد");
            return BadRequest("زاعر اضافه نشد");
        }
        [HttpDelete("{caravanId}/Pilgrims/{pilgrimNationalCode}")]
        public async Task<IActionResult> RemovePilgrim([FromRoute] Guid caravanId, [FromRoute] string pilgrimNationalCode,
                            [FromBody] RemovePilgrimCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.NationalCode = pilgrimNationalCode;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("زاعر حذف شد");
            return BadRequest("زاعر حذف نشد");
        }
        [HttpGet("{caravanId}/Pilgrims")]
        public async Task<IActionResult> GetPilgrims([FromRoute] Guid caravanId, CancellationToken ct)
        {
            var query = new CaravanPilgrimsQuery();
            query.CaravanId = caravanId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Pilgrims);
        }
    }
}
