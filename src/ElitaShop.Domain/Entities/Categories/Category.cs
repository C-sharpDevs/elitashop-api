using ElitaShop.Domain.Entities.Products;

namespace ElitaShop.Domain.Entities.Categories
{
    public class Category : Auditable
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string? CategoryImage { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
