using MediatR;
using Quotes.Application.Wrappers;

namespace Quotes.Application.Services.Accounts.Commands.Register
{
    public class RegisterCommand : IRequest<ApiResponse<Unit>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
