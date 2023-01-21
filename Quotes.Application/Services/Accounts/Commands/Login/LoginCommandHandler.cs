using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Quotes.Application.Interfaces;
using Quotes.Application.Wrappers;
using Quotes.Domain.Constants.Identity;
using Quotes.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quotes.Application.Services.Accounts.Commands.Login
{
    public class LoginCommandHandler : BaseService, IRequestHandler<LoginCommand, ApiResponse<LoginModel>>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(IQuotesDbContext context, IMapper mapper,
            SignInManager<User> signInManager, IConfiguration configuration) : base(context, mapper)
        {
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ApiResponse<LoginModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await GetUser(request);
            if (user is null) return ApiResponse<LoginModel>.Failure("Invalid login attempt!");

            var credentials = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!credentials.Succeeded) return ApiResponse<LoginModel>.Failure("Invalid login attempt!");

            var (token, expire) = await GetAccessToken(user);

            var response = new LoginModel
            {
                Token = token,
                TokenExpireDate = expire,
                User = new UserLoginModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };

            return ApiResponse<LoginModel>.Success(response);
        }

        private async Task<(string token, DateTime expire)> GetAccessToken(User user)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"])), SecurityAlgorithms.HmacSha512);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetIdentityClaims(user)),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
        }

        private static Task<List<Claim>> GetIdentityClaims(User user)
        {
            List<Claim> claims = new();

            if (user.UserRoles.Select(x => x.Role).FirstOrDefault() is Role role)
            {
                claims.AddRange(new List<Claim>
                {
                    new Claim(UserClaimsEnum.Role, role.Name ?? string.Empty),
                    new Claim(UserClaimsEnum.RoleId, user.Id.ToString() ?? string.Empty)
                });
            }

            claims.AddRange(new List<Claim>
            {
                new Claim(UserClaimsEnum.Id, user.Id.ToString() ?? string.Empty),
                new Claim(UserClaimsEnum.UserName, user.UserName ?? string.Empty),
                new Claim(UserClaimsEnum.Email, user.Email ?? string.Empty),
                new Claim(UserClaimsEnum.FirstName, user.FirstName ?? string.Empty),
                new Claim(UserClaimsEnum.LastName, user.LastName ?? string.Empty),
            });
            return Task.FromResult(claims);
        }
        private async Task<User> GetUser(LoginCommand request)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

            return user;
        }
    }
}
