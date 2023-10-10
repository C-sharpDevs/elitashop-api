﻿namespace ElitaShop.Services.Dtos.User
{
    public class UserCreatedDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Intro { get; set; }
        public string? UserImage { get; set; }
    }
}
