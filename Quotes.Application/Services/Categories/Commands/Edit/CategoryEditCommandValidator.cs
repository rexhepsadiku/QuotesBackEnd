using FluentValidation;

namespace Quotes.Application.Services.Categories.Commands.Edit
{
    public class CategoryEditCommandValidator : AbstractValidator<CategoryEditCommand>
    {
        public CategoryEditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
