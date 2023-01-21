using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Commands.Delete
{
    public class QuoteDeleteCommandHandler : BaseService, IRequestHandler<QuoteDeleteCommand, ApiResponse<Unit>>
    {
        public QuoteDeleteCommandHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<Unit>> Handle(QuoteDeleteCommand request, CancellationToken cancellationToken)
        {
            var quote = await _dbContext.Quotes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (quote == null) return ApiResponse<Unit>.Failure("Quote not found!");

            _dbContext.Quotes.Remove(quote);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Quote delete failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
