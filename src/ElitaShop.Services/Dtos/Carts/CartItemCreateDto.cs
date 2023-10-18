namespace ElitaShop.Services.Dtos.Carts
{
    public class CartItemCreateDto
    {        
        public int Quantity { get; set; }
        
        public string? Content { get; set; }

        public long ProductId { get; set; }
    }
}
