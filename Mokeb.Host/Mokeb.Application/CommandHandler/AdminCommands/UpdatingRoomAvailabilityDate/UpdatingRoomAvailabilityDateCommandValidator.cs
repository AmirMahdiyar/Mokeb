using FluentValidation;

namespace Mokeb.Application.CommandHandler.AdminCommands.RemovingRoomAvailability
{
    public class UpdatingRoomAvailabilityDateCommandValidator : AbstractValidator<UpdatingRoomAvailabilityDateCommand>
    {
        public UpdatingRoomAvailabilityDateCommandValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty()
                .WithMessage("Room Id Can't be empty");

            RuleFor(x => x.AvailabilityId)
                .NotEmpty()
                .WithMessage("Availability Id can't be empty");
        }
    }
}
