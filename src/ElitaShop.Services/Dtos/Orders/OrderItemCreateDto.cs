namespace ElitaShop.Services.Dtos.Orders
{
    public class OrderItemCreateDto
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
