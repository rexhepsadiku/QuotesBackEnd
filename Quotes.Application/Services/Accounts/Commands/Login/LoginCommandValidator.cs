using FluentValidation;

namespace Quotes.Application.Services.Accounts.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(16).MinimumLength(6);
        }
    }
}
