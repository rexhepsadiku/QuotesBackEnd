using Quotes.Domain.Entities.Base;

namespace Quotes.Domain.Entities
{
    public class QuoteCategory : BaseEntity
    {
        public Guid QuoteId { get; set; }
        public Quote Quote { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
