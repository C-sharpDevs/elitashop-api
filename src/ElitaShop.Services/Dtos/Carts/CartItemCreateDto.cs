namespace ElitaShop.Services.Dtos.Carts
{
    public class CartItemCreateDto
    {
        public decimal Price { get; set; }
       
        public decimal Discount { get; set; }
        
        public int Quantity { get; set; }
        
        public string Content { get; set; } = string.Empty;
    }
}
