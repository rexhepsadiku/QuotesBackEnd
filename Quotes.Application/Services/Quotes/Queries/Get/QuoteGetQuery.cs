using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.Get
{
    public class QuoteGetQuery : IRequest<ApiResponse<List<QuoteModel>>>
    {
    }
}
