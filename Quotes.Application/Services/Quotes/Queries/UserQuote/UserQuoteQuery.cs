using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.UserQuote
{
    public class UserQuoteQuery : IRequest<ApiResponse<List<UserQuoteModel>>>
    {
    }
}
