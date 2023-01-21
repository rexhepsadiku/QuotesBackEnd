using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.Get
{
    public class QuoteGetQueryHandler : BaseService, IRequestHandler<QuoteGetQuery, ApiResponse<List<QuoteModel>>>
    {
        public QuoteGetQueryHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<List<QuoteModel>>> Handle(QuoteGetQuery request, CancellationToken cancellationToken)
        {
            var quotes = await _dbContext.Quotes
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Image)
                .AsNoTracking()
                .ToListAsync();
            var response = _mapper.Map<List<QuoteModel>>(quotes);

            return ApiResponse<List<QuoteModel>>.Success(response);
        }
    }
}
