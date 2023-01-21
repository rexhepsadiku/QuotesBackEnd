using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Commands.Delete
{
    public class CategoryDeleteCommand : IRequest<ApiResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
