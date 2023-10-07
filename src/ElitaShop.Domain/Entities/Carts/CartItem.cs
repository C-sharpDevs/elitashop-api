using ElitaShop.Domain.Entities.Products;

namespace ElitaShop.Domain.Entities.Carts
{

    public class CartItem : Auditable
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Cart))]
        public long CartId { get; set; }
        public Cart Cart { get; set; }
    }
}


