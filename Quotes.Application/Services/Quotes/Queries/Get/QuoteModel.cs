using Quotes.Application.Models;
using Quotes.Application.Services.Categories.Queries.Get;

namespace Quotes.Application.Services.Quotes.Queries.Get
{
    public class QuoteModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public UserModel User { get; set; }
        public ImageModel Image { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}
