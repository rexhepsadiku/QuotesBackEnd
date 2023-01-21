using Quotes.Domain.Entities.Base;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<QuoteCategory> Categories { get; set; }
    }
}
