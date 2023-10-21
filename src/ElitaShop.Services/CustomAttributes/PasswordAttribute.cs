using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ElitaShop.Services.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string password = value.ToString();

            if (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d\s]).{7,}$"))
            {
                return true;
            }

            return false;
        }
    }
}
