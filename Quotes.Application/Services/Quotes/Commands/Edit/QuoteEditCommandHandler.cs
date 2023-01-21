using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Commands.Edit
{
    public class QuoteEditCommandHandler : BaseService, IRequestHandler<QuoteEditCommand, ApiResponse<Unit>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuoteEditCommandHandler(IQuotesDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<Unit>> Handle(QuoteEditCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
            if (userId is null) return ApiResponse<Unit>.Failure("Invalid user token!");

            var quote = await _dbContext.Quotes
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (quote == null) return ApiResponse<Unit>.Failure("Quote not found!");

            var updateQuote = _mapper.Map(request, quote);
            updateQuote.UserId = new Guid(userId);

            _dbContext.Quotes.Update(updateQuote);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Quote update failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
