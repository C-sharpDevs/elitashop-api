using ElitaShop.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElitaShop.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public string Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal? Shipping { get; set; }
        public decimal GrandTotal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string? Content { get; set; }

        [ForeignKey(nameof(User))]
        public long  UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }

}
