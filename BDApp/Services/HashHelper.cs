using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Cryptography;
using System.Text;

namespace BDApp.Services
{
    public class HashHelper
    {
        public static string Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("name of argument cannot be null or empty", nameof(input));

            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static bool VerifyHash(string input, string storedHash)
        {
            return Hash(input) == storedHash;
        }
    }
}
