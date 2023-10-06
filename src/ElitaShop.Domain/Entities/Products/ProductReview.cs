namespace ElitaShop.Domain.Entities.Products
{
    public class ProductReview:Auditable
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public bool Published { get; set; }=false;
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }


        public Product Product { get; set; }
    }
}
