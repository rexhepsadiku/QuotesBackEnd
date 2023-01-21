using AutoMapper;
using Quotes.Application.Models;
using Quotes.Application.Services.Accounts.Commands.Register;
using Quotes.Application.Services.Categories.Commands.Add;
using Quotes.Application.Services.Categories.Commands.Edit;
using Quotes.Application.Services.Categories.Queries.Get;
using Quotes.Application.Services.Categories.Queries.GetById;
using Quotes.Application.Services.Quotes.Commands.Add;
using Quotes.Application.Services.Quotes.Commands.Edit;
using Quotes.Application.Services.Quotes.Queries.Get;
using Quotes.Application.Services.Quotes.Queries.GetById;
using Quotes.Application.Services.Quotes.Queries.UserQuote;
using Quotes.Domain.Entities;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Category mappings
            CreateMap<CategoryAddCommand, Category>();
            CreateMap<CategoryEditCommand, Category>();
            CreateMap<Category, CategoryModel>();
            CreateMap<Category, CategoryByIdModel>();

            //Quote mappings
            CreateMap<QuoteAddCommand, Quote>();
            CreateMap<QuoteEditCommand, Quote>();
            CreateMap<Quote, QuoteModel>()
                .ForPath(dto => dto.Categories, x => x.MapFrom(x => x.Categories.Select(x => x.Category)));
            CreateMap<Quote, QuoteByIdModel>()
                .ForPath(dto => dto.Categories, x => x.MapFrom(x => x.Categories.Select(x => x.Category)));
            CreateMap<Guid, QuoteCategory>().ForMember(x => x.CategoryId, opt => opt.MapFrom(dto => dto));
            CreateMap<Quote, UserQuoteModel>()
                .ForPath(dto => dto.Categories, x => x.MapFrom(x => x.Categories.Select(x => x.Category)));

            //Account mappings
            CreateMap<RegisterCommand, User>()
                .ForMember(user => user.UserName, opt => opt.MapFrom(req => req.Email))
                .ForMember(user => user.PasswordHash, opt => opt.MapFrom(req => req.Password));

            //User mappings
            CreateMap<User, UserModel>();

            //Image mappings
            CreateMap<Image, ImageModel>();
        }
    }
}
