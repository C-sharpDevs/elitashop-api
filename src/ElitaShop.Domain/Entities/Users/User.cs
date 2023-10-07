namespace ElitaShop.Domain.Entities.Users
{
    public class User:Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Vendor {get; set; }
        public DateTime RegistiredAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public string? Intro { get; set; }
        public string? UserImage { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; } 
    }
}
