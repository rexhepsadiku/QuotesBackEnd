using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quotes.Application.Interfaces;
using Quotes.Domain.Entities;
using Quotes.Domain.Entities.Identity;
using System.Reflection;

namespace Quotes.Infrastructure.Persistence
{
    public class QuotesDbContext : IdentityDbContext<User, Role, Guid, UserClaim,
        UserRole, UserLogin, RoleClaim, UserToken> , IQuotesDbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuoteCategory> QuoteCategories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
