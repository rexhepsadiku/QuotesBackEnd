namespace Quotes.Application.Services.Accounts.Commands.Login
{
    public class LoginModel
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public UserLoginModel User { get; set; }
    }
}
