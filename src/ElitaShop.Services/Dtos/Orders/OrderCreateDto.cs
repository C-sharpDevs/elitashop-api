using ElitaShop.Domain.Enums;
using ElitaShop.Services.CustomAttributes;

namespace ElitaShop.Services.Dtos.Orders
{
    public class OrderCreateDto
    {
        public OrderStatus Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ItemDiscount { get; set; }
        [Length]
        public string FirstName { get; set; } = string.Empty;
        [Length]
        public string LastName { get; set; } = string.Empty;
        [Length]
        public string MiddleName { get; set; } = string.Empty;
        [PhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;
        [Email]
        public string Email { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? Content { get; set; }
    }
}
