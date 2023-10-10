namespace ElitaShop.Services.Dtos.Products
{
    public class ProductReviewCreateDto
    {
        public long ProductId { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public bool Published { get; set; } = false;

        public string Content { get; set; }
    }
}
