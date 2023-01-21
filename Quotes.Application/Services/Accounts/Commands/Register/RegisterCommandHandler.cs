using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;
using Quotes.Domain.Constants.Identity;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Application.Services.Accounts.Commands.Register
{
    public class RegisterCommandHandler : BaseService, IRequestHandler<RegisterCommand, ApiResponse<Unit>>
    {
        private readonly UserManager<User> _userManager;
        public RegisterCommandHandler(IQuotesDbContext context, IMapper mapper, UserManager<User> userManager) : base(context, mapper)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<Unit>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var checkUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkUser != null) return ApiResponse<Unit>.Failure("User with this email is already registered!");

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) return ApiResponse<Unit>.Failure("User registration failed!");
            await _userManager.AddToRoleAsync(user, RolesEnum.User);

            return ApiResponse<Unit>.Success(Unit.Value);
        }
    }
}
