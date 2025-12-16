using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.AcceptingARequestedRequest;
using Mokeb.Application.CommandHandler.AdminCommands.ActivingPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.AdminLogIn;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingCaravansPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingEntranceDateOfACaravan;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingExitDateOfAPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.DeleteCaravan;
using Mokeb.Application.CommandHandler.AdminCommands.IncreasingRequestsNumberOfPeople;
using Mokeb.Application.CommandHandler.AdminCommands.RejectingARequestedRequest;
using Mokeb.Application.CommandHandler.PrincipalsLogOut;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.CapacityReportByDate;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingIncomingOrAcceptedRequestByDate;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingOutGoingOrAcceptedRequestsByDate;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingPrincipalInformation;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.LookingOnRoomAvailabilitiesOnARangeOfDates;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.LookingOnCaravans;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingIndividuals.LookingOnIndividuals;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingRequestedRequests.GettingRoomAvailabilitiesOnADateRange;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingRequestedRequests.LookingOnRequestedRequests;

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
            var query = new GettingIncomingOrAcceptedRequestByDateQuery();
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

        [HttpGet("/GettingOutGoingOrAcceptedCaravansRequestsAtADay/{date}")]
        public async Task<IActionResult> GettingOutGoingOrAcceptedCaravansRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingOutGoingOrAcceptedRequestsByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }

        [HttpGet("/GettingPrincipalInformation/{principalId}")]
        public async Task<IActionResult> GettingCaravanInformation([FromRoute] Guid principalId, CancellationToken ct)
        {
            var query = new GettingPrincipalInformationQuery();
            query.PrincipalId = principalId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Principal);
        }

        [HttpGet("GettingStatsOfADay/{date}")]
        public async Task<IActionResult> GettingStats([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new CapacityReportByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpPut("/requests/{requestId}/AddRoomAvailability/RoomAvailabilities/{roomAvailabilityId}")]
        public async Task<IActionResult> AddRoomAvailabilityToAnAcceptedOrEnteredRequest([FromRoute] Guid requestId, [FromRoute] Guid roomAvailabilityId,
            [FromBody] AddingRoomAvailabilityToAnAcceptedRequestCommand command, CancellationToken ct)
        {
            command.RequestId = requestId;
            command.RoomAvailabilityId = roomAvailabilityId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("RoomAvailability Added Successfully");
            return BadRequest("RoomAvailability didn't Add Successfully");
        }

        [HttpPut("/requests/{requestId}/AddRoomAvailability/RoomAvailabilities")]
        public async Task<IActionResult> LookingOnRoomAvailabilitiesToAddInRequest([FromRoute] Guid requestId,
             [FromBody] LookingOnRoomAvailabilitiesOnARangeOfDatesQuery query, CancellationToken ct)
        {
            query.RequestId = requestId;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        [HttpPut("/requests/{requestId}/ChangingDateOfEntrance")]
        public async Task<IActionResult> ChangingDateOfEntrance([FromRoute] Guid requestId,
            [FromBody] ChangingEntranceDateOfAPrincipalCommand command, CancellationToken ct)
        {
            command.RequestId = requestId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("DateOfEntrance Changed Successfully");
            return BadRequest("DateOfEntrance Didn't change");
        }
        [HttpPut("/requests/{requestId}/ChangingExitDate")]
        public async Task<IActionResult> ChangingExitDate([FromRoute] Guid requestId,
            [FromBody] ChangingExitDateOfAPrincipalCommand command, CancellationToken ct)
        {
            command.RequestId = requestId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("ExitDate Changed Successfully");
            return BadRequest("ExitDate Didn't change");
        }
        [HttpGet("ManagingRequests/{enterDate}")]
        public async Task<IActionResult> GetRequestedRequests([FromRoute] DateOnly enterDate, CancellationToken ct)
        {
            var query = new LookingOnRequestedRequestsQuery();
            query.EntranceDate = enterDate;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Requests);
        }
        [HttpGet("ManagingRequests/{enterDate}/Request/{requestId}/CheckingRoomAvailabilities/{exitDate}")]
        public async Task<IActionResult> CheckRequest([FromRoute] DateOnly enterDate, DateOnly exitDate, CancellationToken ct)
        {
            var query = new GettingRoomAvailabilitiesOnADateRangeQuery();
            query.EnterTime = enterDate;
            query.ExitTime = exitDate;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.MaleRoomAvailabilities.Concat(result.FemaleRoomAvailabilities));
        }
        [HttpPost("ManagingRequests/{enterDate}/Request/{requestId}/CheckingRoomAvailabilities/{exitDate}/AcceptRequest")]
        public async Task<IActionResult> CheckRequest([FromBody] AcceptingARequestedRequestCommand command, [FromRoute] Guid requestId, CancellationToken ct)
        {
            command.RequestId = requestId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("درخواست قبول شد");
            return BadRequest("درخواست قبول نشد");
        }
        [HttpPost("ManagingRequests/{enterDate}/Request/{requestId}/CheckingRoomAvailabilities/{exitDate}/RejectingRequest")]
        public async Task<IActionResult> CheckRequest([FromBody] RejectingARequestedRequestCommand command, [FromRoute] Guid requestId, CancellationToken ct)
        {
            command.RequestId = requestId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("درخواست قبول شد");
            return BadRequest("درخواست قبول نشد");
        }
        [HttpGet("ManagingCaravans")]
        public async Task<IActionResult> ManagingCaravans(CancellationToken ct)
        {
            var query = new LookingOnCaravansQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        [HttpDelete("ManagingCaravans/{caravanId}")]
        public async Task<IActionResult> DeletingCaravan([FromRoute] Guid caravanId, [FromBody] DeleteCaravanCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("کاروان با موفقیت حذف شد");
            return BadRequest("کاروان حذف نشد");
        }
        [HttpPut("ManagingCaravans/{caravanId}")]
        public async Task<IActionResult> ChangingCaravansPrincipal([FromRoute] Guid caravanId, [FromBody] ChangingCaravansPrincipalCommand command, CancellationToken ct)
        {
            command.CaravanId = caravanId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok(" مدیرکاروان با موفقیت تغییر کرد");
            return BadRequest("مدیر کاروان تغییر نکرد");
        }
        [HttpPut("ManagingCaravans/{principalId}/ActivateOrDeactivatePrincipal")]
        public async Task<IActionResult> ActivateOrDeactivatePrincipal([FromRoute] Guid principalId, [FromBody] ActivingOrDeActivingPrincipalCommand command, CancellationToken ct)
        {
            command.PrincipalId = principalId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("درخواست با موفقیت انحام یافت");
            return BadRequest("درخواست انجام نشد");
        }
        [HttpGet("ManagingIndividuals")]
        public async Task<IActionResult> ManagingIndividuals(CancellationToken ct)
        {
            var query = new LookingOnIndividualsQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
    }
}
