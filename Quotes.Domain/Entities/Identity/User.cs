using Microsoft.AspNetCore.Identity;

namespace Quotes.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
