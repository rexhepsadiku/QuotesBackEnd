using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Commands.Add
{
    public class CategoryAddCommand : IRequest<ApiResponse<Unit>>
    {
        public string Name { get; set; }
    }
}
