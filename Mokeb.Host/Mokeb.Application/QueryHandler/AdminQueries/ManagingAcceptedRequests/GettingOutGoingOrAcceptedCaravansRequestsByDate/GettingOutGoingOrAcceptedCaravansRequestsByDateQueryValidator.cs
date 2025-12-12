using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingOutGoingOrAcceptedCaravansRequestsByDate
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
