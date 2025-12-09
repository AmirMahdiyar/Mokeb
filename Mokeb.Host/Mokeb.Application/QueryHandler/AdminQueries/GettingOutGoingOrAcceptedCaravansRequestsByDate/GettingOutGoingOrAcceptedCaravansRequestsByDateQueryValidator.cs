using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingOutGoingOrAcceptedCaravansRequestsByDate
{
    public class GettingOutGoingOrAcceptedCaravansRequestsByDateQueryValidator : AbstractValidator<GettingOutGoingOrAcceptedCaravansRequestsByDateQuery>
    {
        public GettingOutGoingOrAcceptedCaravansRequestsByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date Can't be empty");
        }
    }
}
