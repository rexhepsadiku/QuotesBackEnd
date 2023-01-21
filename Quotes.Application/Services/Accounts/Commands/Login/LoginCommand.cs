using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Accounts.Commands.Login
{
    public class LoginCommand : IRequest<ApiResponse<LoginModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
