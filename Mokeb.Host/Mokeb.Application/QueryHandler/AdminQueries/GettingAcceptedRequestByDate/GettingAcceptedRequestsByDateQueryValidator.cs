using FluentValidation;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingAcceptedRequestsByDateQueryValidator : AbstractValidator<GettingAcceptedRequestsByDateQuery>
    {
        public GettingAcceptedRequestsByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date Can't be empty");
        }
    }
}
