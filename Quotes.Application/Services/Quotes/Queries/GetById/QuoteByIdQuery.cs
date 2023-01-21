using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.GetById
{
    public class QuoteByIdQuery : IRequest<ApiResponse<QuoteByIdModel>>
    {
        public Guid Id { get; set; }
    }
}
