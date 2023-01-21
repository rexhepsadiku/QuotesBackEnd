using AutoMapper;
using Quotes.Application.Interfaces;

namespace Quotes.Application.Services
{
    public class BaseService
    {
        protected readonly IQuotesDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(IQuotesDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
    }
}
