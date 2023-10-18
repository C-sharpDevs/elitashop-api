namespace ElitaShop.Services.Dtos.Carts
{
    public class CartItemUpdateDto 
    {
        public int Quantity { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
