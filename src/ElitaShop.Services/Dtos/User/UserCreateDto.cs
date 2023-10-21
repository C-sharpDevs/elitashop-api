using ElitaShop.Services.CustomAttributes;

namespace ElitaShop.Services.Dtos.User
{
    public class UserCreateDto
    {
        [Length]
        public string FirstName { get; set; }
        [Length]
        public string LastName { get; set; }
        [Length]
        public string MiddleName { get; set; }
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        [Email]
        public string Email { get; set; }
        [Password]
        public string Password { get; set; }
        public string? Intro { get; set; }
        public IFormFile UserAvatar { get; set; } = default!;
    }
}
