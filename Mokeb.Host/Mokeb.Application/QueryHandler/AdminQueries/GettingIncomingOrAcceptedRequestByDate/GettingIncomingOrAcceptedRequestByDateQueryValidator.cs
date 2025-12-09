using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingIncomingOrAcceptedRequestByDateQueryValidator : AbstractValidator<GettingIncomingOrAcceptedRequestByDateQuery>
    {
        public GettingIncomingOrAcceptedRequestByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date Can't be empty");
        }
    }
}
