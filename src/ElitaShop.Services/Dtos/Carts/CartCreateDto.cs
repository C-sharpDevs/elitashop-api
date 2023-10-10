namespace ElitaShop.Services.Dtos.Carts
{
    public class CartCreateDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string MiddleName { get; set; } = string.Empty;
        
        public string PhoneNumber { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string SessionId { get; set; } = string.Empty;

        public CartStatus Status { get; set; }

        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;
   
        public string City { get; set; } = string.Empty;
        
        public string Province { get; set; } = string.Empty;
        
        public string Country { get; set; } = string.Empty;
        
        public string? Content { get; set; }    
    }
}
