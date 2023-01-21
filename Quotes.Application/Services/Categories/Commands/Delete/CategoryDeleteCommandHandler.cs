using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Commands.Delete
{
    public class CategoryDeleteCommandHandler : BaseService, IRequestHandler<CategoryDeleteCommand, ApiResponse<Unit>>
    {
        public CategoryDeleteCommandHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<Unit>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category == null) return ApiResponse<Unit>.Failure("Category not found!");

            _dbContext.Categories.Remove(category);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Category delete failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
