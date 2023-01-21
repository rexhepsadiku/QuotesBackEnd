using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Queries.GetById
{
    public class CategoryByIdQuery : IRequest<ApiResponse<CategoryByIdModel>>
    {
        public Guid Id { get; set; }
    }
}
