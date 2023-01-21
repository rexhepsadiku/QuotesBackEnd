using FluentValidation;

namespace Quotes.Application.Services.Quotes.Commands.Add
{
    public class QuoteAddCommandValidator : AbstractValidator<QuoteAddCommand>
    {
        public QuoteAddCommandValidator()
        {
            RuleFor(x => x.Text).NotEmpty().NotNull();
            RuleFor(x => x.Categories).NotEmpty().NotNull();
        }
    }
}
