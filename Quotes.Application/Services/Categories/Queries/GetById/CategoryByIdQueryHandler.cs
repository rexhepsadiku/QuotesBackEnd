using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Queries.GetById
{
    public class CategoryByIdQueryHandler : BaseService, IRequestHandler<CategoryByIdQuery, ApiResponse<CategoryByIdModel>>
    {
        public CategoryByIdQueryHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<CategoryByIdModel>> Handle(CategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category == null) return ApiResponse<CategoryByIdModel>.Failure("Category not found!");

            var response = _mapper.Map<CategoryByIdModel>(category);
            return ApiResponse<CategoryByIdModel>.Success(response);
        }
    }
}
