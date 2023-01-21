using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Infrastructure.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            Relations(builder);
            builder.ToTable("Users");
        }

        private static void Relations(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.UserRoles)
              .WithOne(z => z.User)
              .HasForeignKey(ur => ur.UserId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
