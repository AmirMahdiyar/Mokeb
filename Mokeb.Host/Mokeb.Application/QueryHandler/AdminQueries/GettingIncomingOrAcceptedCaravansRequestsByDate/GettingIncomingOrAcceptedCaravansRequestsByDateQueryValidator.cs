using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryValidator : AbstractValidator<GettingIncomingOrAcceptedCaravansRequestsByDateQuery>
    {
        public GettingIncomingOrAcceptedCaravansRequestsByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date Can't be empty");
        }
    }
}
