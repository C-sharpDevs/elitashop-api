using ElitaShop.Domain.Enums;
using ElitaShop.Services.CustomAttributes;

namespace ElitaShop.Services.Dtos.Orders
{
    public class OrderUpdateDto
    {
        public OrderStatus Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ItemDiscount { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? Content { get; set; }
    }
}
