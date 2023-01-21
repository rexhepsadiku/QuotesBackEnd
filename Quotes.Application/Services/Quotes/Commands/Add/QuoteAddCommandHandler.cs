using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;
using Quotes.Domain.Entities;

namespace Quotes.Application.Services.Quotes.Commands.Add
{
    public class QuoteAddCommandHandler : BaseService, IRequestHandler<QuoteAddCommand, ApiResponse<Unit>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuoteAddCommandHandler(IQuotesDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<Unit>> Handle(QuoteAddCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
            if (userId is null) return ApiResponse<Unit>.Failure("Invalid user token!");

            var quote = _mapper.Map<Quote>(request);
            quote.UserId = new Guid(userId);
            quote.ImageId = await GetRandomImageId();

            await _dbContext.Quotes.AddAsync(quote);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Quote creation failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }

        private async Task<Guid> GetRandomImageId()
        {
            List<Guid> imageIds = await _dbContext.Images.Select(x => x.Id).ToListAsync();
            Random random = new Random();
            int index = random.Next(imageIds.Count);
            Guid imageId = imageIds[index];

            return imageId;
        }
    }
}
