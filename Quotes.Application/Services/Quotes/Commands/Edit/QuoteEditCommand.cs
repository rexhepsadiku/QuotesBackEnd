using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Commands.Edit
{
    public class QuoteEditCommand : IRequest<ApiResponse<Unit>>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
