using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Categories.Queries.Get
{
    public class CategoryGetQueryHandler : BaseService, IRequestHandler<CategoryGetQuery, ApiResponse<List<CategoryModel>>>
    {
        public CategoryGetQueryHandler(IQuotesDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ApiResponse<List<CategoryModel>>> Handle(CategoryGetQuery request, CancellationToken cancellationToken)
        {
            var categories = await _dbContext.Categories.ToListAsync();
            var response = _mapper.Map<List<CategoryModel>>(categories);
            return ApiResponse<List<CategoryModel>>.Success(response);
        }
    }
}
