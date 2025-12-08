using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.AddingRoom;
using Mokeb.Application.CommandHandler.AdminCommands.AddingRoomAvailability;
using Mokeb.Application.CommandHandler.AdminCommands.RemovingRoom;
using Mokeb.Application.CommandHandler.AdminCommands.RemovingRoomAvailability;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] AddingRoomCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Room Added Successfully");
            return BadRequest("Room Didn't add");
        }
        [HttpDelete("{roomId}")]
        public async Task<IActionResult> RemoveRoom([FromRoute] Guid roomId, [FromBody] RemovingRoomCommand command, CancellationToken ct)
        {
            command.roomId = roomId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Room Removed Successfully");
            return BadRequest("Room Didn't Remove");
        }
        [HttpPost("{roomId}/RoomAvailability")]
        public async Task<IActionResult> AddRoomAvailability([FromRoute] Guid roomId, [FromBody] AddingRoomAvailabilityCommand command, CancellationToken ct)
        {
            command.roomId = roomId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("RoomAvailability Added Successfully");
            return BadRequest("RoomAvailability Didn't add");
        }
        [HttpPut("{roomId}/{roomAvailabilityId}/ChangeDate")]
        public async Task<IActionResult> ChangeDateOfAvailableRoom([FromRoute] Guid roomId, [FromRoute] Guid roomAvailabilityId, [FromBody] UpdatingRoomAvailabilityDateCommand command, CancellationToken ct)
        {
            command.RoomId = roomId;
            command.AvailabilityId = roomAvailabilityId;
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Success)
                return Ok("Date Changed Successfully");
            return BadRequest("Date Didn't change");
        }
    }
}
