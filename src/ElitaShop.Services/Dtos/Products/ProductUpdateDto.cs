using Microsoft.AspNetCore.Http;

namespace ElitaShop.Services.Dtos.Products
{
    public class ProductUpdateDto
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public bool IsShop { get; set; }
        public IFormFile? ProductImage { get; set; } = default!;
    }
}
