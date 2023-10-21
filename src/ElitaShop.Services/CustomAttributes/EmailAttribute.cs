using System.ComponentModel.DataAnnotations;

namespace ElitaShop.Services.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string email = value.ToString();

            if (System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
            {
                return true;
            }

            return false;
        }
    }
}
