namespace ElitaShop.Services.Dtos.Carts
{
    public class CartItemGetDto
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Disount { get; set; }
        public int Quantity { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
