using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Quotes.Queries.UserQuote
{
    public class UserQuoteQueryHandler : BaseService, IRequestHandler<UserQuoteQuery, ApiResponse<List<UserQuoteModel>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserQuoteQueryHandler(IQuotesDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<List<UserQuoteModel>>> Handle(UserQuoteQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
            if (userId is null) return ApiResponse<List<UserQuoteModel>>.Failure("Invalid user token!");
            var userIdGuid = new Guid(userId);

            var quotes = await _dbContext.Quotes
                .Where(x => x.UserId == userIdGuid)
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Image)
                .AsNoTracking()
                .ToListAsync();

            var response = _mapper.Map<List<UserQuoteModel>>(quotes);
            return ApiResponse<List<UserQuoteModel>>.Success(response);
        }
    }
}
