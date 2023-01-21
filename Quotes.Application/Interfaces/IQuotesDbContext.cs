using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Entities;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Application.Interfaces
{
    public interface IQuotesDbContext
    {
        DbSet<Quote> Quotes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<QuoteCategory> QuoteCategories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
