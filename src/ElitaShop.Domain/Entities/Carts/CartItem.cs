using System.Text.Json.Serialization;

namespace ElitaShop.Domain.Entities.Carts
{

    public class CartItem : Auditable
    {
        public int Quantity { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Cart))]
        public long CartId { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
    }
}


