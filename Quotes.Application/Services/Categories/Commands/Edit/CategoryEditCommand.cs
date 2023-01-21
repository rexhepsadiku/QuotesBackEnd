using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Commands.Edit
{
    public class CategoryEditCommand : IRequest<ApiResponse<Unit>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
