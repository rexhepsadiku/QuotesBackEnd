using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Queries.Get
{
    public class CategoryGetQuery : IRequest<ApiResponse<List<CategoryModel>>>
    {
    }
}
