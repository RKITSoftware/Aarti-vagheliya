using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography.BL
{
    /// <summary>
    /// Provides methods for computing hash values using various hashing algorithms.
    /// </summary>
    public class BLHashing
    {
        /// <summary>
        /// Computes the SHA256 hash value of the input string.
        /// </summary>
        /// <param name="input">The input string to compute the hash value for.</param>
        /// <returns>The SHA256 hash value as a hexadecimal string.</returns>
        public static string ComputeSHA256Hash(string input)
        {
             // Create an instance of the SHA256 hashing algorithm
            using (var sha256 = SHA256.Create())
            {
                // Compute the hash value of the input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string representation
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                // Return the hexadecimal string representation of the hash value
                return builder.ToString();
            }
        }
    }
}
