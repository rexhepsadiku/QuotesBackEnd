using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Commands.Delete
{
    public class QuoteDeleteCommand : IRequest<ApiResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
