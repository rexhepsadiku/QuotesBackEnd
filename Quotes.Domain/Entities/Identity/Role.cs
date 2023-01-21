using Microsoft.AspNetCore.Identity;

namespace Quotes.Domain.Entities.Identity
{ 
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
