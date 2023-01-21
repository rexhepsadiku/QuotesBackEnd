using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Commands.Edit
{
    public class CategoryEditCommandHandler : BaseService, IRequestHandler<CategoryEditCommand, ApiResponse<Unit>>
    {
        public CategoryEditCommandHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<Unit>> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category == null) return ApiResponse<Unit>.Failure("Category not found!");

            var updateCategory = _mapper.Map(request, category);
            _dbContext.Categories.Update(updateCategory);
            var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return ApiResponse<Unit>.Failure("Category update failed!");

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
