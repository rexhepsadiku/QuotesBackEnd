using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.GetById
{
    public class QuoteByIdQueryHandler : BaseService, IRequestHandler<QuoteByIdQuery, ApiResponse<QuoteByIdModel>>
    {
        public QuoteByIdQueryHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<QuoteByIdModel>> Handle(QuoteByIdQuery request, CancellationToken cancellationToken)
        {
            var quote = await _dbContext.Quotes
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (quote == null) return ApiResponse<QuoteByIdModel>.Failure("Quote not found!");

            var response = _mapper.Map<QuoteByIdModel>(quote); 

            return ApiResponse<QuoteByIdModel>.Success(response);
        }
    }
}
