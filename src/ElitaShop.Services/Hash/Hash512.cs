using System.Security.Cryptography;
using System.Text;

namespace ElitaShop.Services.Hash
{
    public static class Hash512
    {
        public static string ComputeSHA512HashFromString(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}