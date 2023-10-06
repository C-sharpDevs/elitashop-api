using ElitaShop.Domain.Entities.Categories;

namespace ElitaShop.Domain.Entities.Products
{
    public class ProductCategory : Auditable
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
