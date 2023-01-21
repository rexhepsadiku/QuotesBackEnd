using AutoMapper;
using MediatR;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;
using Quotes.Domain.Entities;

namespace Quotes.Application.Services.Categories.Commands.Add
{
    public class CategoryAddCommandHandler : BaseService, IRequestHandler<CategoryAddCommand, ApiResponse<Unit>>
    {
        public CategoryAddCommandHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<Unit>> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _dbContext.Categories.AddAsync(category);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Category creation failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
