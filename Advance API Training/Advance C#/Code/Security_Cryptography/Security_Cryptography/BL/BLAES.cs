using System;
using System.Security.Cryptography;

namespace Security_Cryptography.BL
{
    /// <summary>
    /// Provides methods for AES encryption and decryption.
    /// </summary>
    public class BLAES
    {
        private static readonly byte[] Key = new byte[32]; // 256-bit key
        private static readonly byte[] IV = new byte[16];  // 128-bit IV

        /// <summary>
        /// Encrypts the input plain text using AES encryption.
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted.</param>
        /// <returns>The Base64-encoded ciphertext.</returns>
        public string Encrypt(string plainText)
        {
            // Create an AES object
            using (var aesAlg = Aes.Create())
            {
                // Set the key and IV
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Encrypt the plain text bytes
                byte[] cipherBytes = encryptor.TransformFinalBlock(
                    System.Text.Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);

                // Return the encrypted data as Base64 string
                return Convert.ToBase64String(cipherBytes);
            }
        }


        /// <summary>
        /// Decrypts the input ciphertext using AES decryption.
        /// </summary>
        /// <param name="cipherText">The Base64-encoded ciphertext to be decrypted.</param>
        /// <returns>The decrypted plain text.</returns>
        public string Decrypt(string cipherText)
        {
            // Create an AES object
            using (var aesAlg = Aes.Create())
            {
                // Set the key and IV
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Convert Base64-encoded cipher text to bytes
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the cipher text bytes
                byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                // Convert decrypted bytes to UTF-8 encoded plain text
                return System.Text.Encoding.UTF8.GetString(plainBytes);
            }
        }
    }
}
