using FluentValidation;

namespace Mokeb.Application.QueryHandler.CaravanRequests
{
    public class CaravanRequestsQueryValidator : AbstractValidator<CaravanRequestsQuery>
    {
        public CaravanRequestsQueryValidator()
        {
            RuleFor(x => x.CaravanId)
                .NotEmpty()
                .WithMessage("شناسه کاروان نمیتواند خالی باشد");
        }
    }
}
