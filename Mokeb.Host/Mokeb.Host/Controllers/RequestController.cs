using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingEntranceDateOfACaravan;
using Mokeb.Application.CommandHandler.AdminCommands.ChangingExitDateOfAPrincipal;
using Mokeb.Application.CommandHandler.AdminCommands.IncreasingRequestsNumberOfPeople;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingIncomingOrAcceptedRequestByDate;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingOutGoingOrAcceptedRequestsByDate;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForEnteredOrDelayInEntrance;
using Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForExitedOrDelayInExited;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/IncomingOrAccepted/{date}")]
        public async Task<IActionResult> GettingRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingIncomingOrAcceptedRequestByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }
        [HttpGet("/OutgoingOrAccepted/{date}")]
        public async Task<IActionResult> GettingOutGoingOrAcceptedRequests([FromRoute] DateOnly date, CancellationToken ct)
        {
            var query = new GettingOutGoingOrAcceptedRequestsByDateQuery();
            query.Date = date;
            query.Validate();
            var result = await _mediator.Send(query, ct);
            return Ok(result.Response);
        }
        [HttpPut("/{requestId}/RoomAvailabilities/{roomAvailabilityId}/AddRoomAvailability")]
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
        [HttpPut("/{requestId}/ChangingDateOfEntrance")]
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
        [HttpPut("/{requestId}/ChangingExitDate")]
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
        [HttpGet("IncomingOrAccepted/{date}/Search/{input}")]
        public async Task<IActionResult> SearchForIncomingOrAccepted([FromRoute] string input, [FromRoute] DateOnly date, CancellationToken ct)
        {
            var command = new SearchForEnteredOrDelayInEntranceCommand();
            command.Input = input;
            command.Date = date;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            return Ok(result.Response);
        }
        [HttpGet("OutgoingOrAccepted/{date}/Search/{input}")]
        public async Task<IActionResult> SearchForOutgoingOrAccepted([FromRoute] string input, [FromRoute] DateOnly date, CancellationToken ct)
        {
            var command = new SearchForExitedOrDelayInExitedCommand();
            command.Input = input;
            command.Date = date;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            return Ok(result.Response);
        }
    }
}
