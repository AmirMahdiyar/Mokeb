using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingAcceptedCaravansRequestsByDateQueryValidator : AbstractValidator<GettingAcceptedCaravansRequestsByDateQuery>
    {
        public GettingAcceptedCaravansRequestsByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date Can't be empty");
        }
    }
}
