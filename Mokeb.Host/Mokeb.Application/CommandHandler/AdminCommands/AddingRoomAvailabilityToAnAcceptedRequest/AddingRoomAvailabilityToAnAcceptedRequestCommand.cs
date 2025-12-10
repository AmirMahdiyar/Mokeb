using MediatR;
using Mokeb.Application.CommandHandler.Base;

namespace Mokeb.Application.CommandHandler.AdminCommands.IncreasingRequestsNumberOfPeople
{
    public class AddingRoomAvailabilityToAnAcceptedRequestCommand : CommandBase, IRequest<AddingRoomAvailabilityToAnAcceptedRequestCommandResponse>
    {
        public Guid RequestId { get; set; }
        public Guid RoomAvailabilityId { get; set; }
        public uint Amount { get; set; }
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
