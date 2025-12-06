using FluentValidation;

namespace Mokeb.Application.CommandHandler.AdminLogIn
{
    public class AdminLogInCommandValidator : AbstractValidator<AdminLogInCommand>
    {
        public AdminLogInCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username Cant be empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password Cant Be empty");
        }
    }
}
