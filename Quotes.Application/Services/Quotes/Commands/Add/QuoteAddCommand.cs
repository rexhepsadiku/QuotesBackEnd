using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Commands.Add
{
    public class QuoteAddCommand : IRequest<ApiResponse<Unit>>
    {
        public string Text { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
