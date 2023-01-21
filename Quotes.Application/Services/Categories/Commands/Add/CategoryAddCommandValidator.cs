using FluentValidation;

namespace Quotes.Application.Services.Categories.Commands.Add
{
    public class CategoryAddCommandValidator : AbstractValidator<CategoryAddCommand>
    {
        public CategoryAddCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
