using FluentValidation;

namespace Quotes.Application.Services.Quotes.Commands.Edit
{
    public class QuoteEditCommandValidator : AbstractValidator<QuoteEditCommand>
    {
        public QuoteEditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Text).NotEmpty().NotNull();
            RuleFor(x => x.Categories).NotEmpty().NotNull();
        }
    }
}
