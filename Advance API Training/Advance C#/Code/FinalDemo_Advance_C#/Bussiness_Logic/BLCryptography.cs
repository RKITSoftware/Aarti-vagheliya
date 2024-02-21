using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for encryption and decryption using Rijndael algorithm.
    /// </summary>
    public class BLCryptography
    {
        #region Private member

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("ThisIsASecretKey1234567890123456"); // 256-bit key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 128-bit IV

        #endregion

        #region Public methods

        /// <summary>
        /// Encrypts the input plain text using Rijndael encryption.
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted.</param>
        /// <returns>The Base64-encoded ciphertext.</returns>
        public static string Encrypt(string plainText)
        {
            // Create a Rijndael object
            using (var rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create a memory stream to store the encrypted data
                using (var msEncrypt = new MemoryStream())
                {
                    // Create a crypto stream to perform encryption
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        // Create a stream writer to write the encrypted data
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write the plain text to the stream
                            swEncrypt.Write(plainText);
                        }
                    }
                    // Convert the encrypted data to Base64 string and return
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts the input ciphertext using Rijndael decryption.
        /// </summary>
        /// <param name="cipherText">The Base64-encoded ciphertext to be decrypted.</param>
        /// <returns>The decrypted plain text.</returns>
        public static string Decrypt(string cipherText)
        {
            // Convert Base64-encoded cipher text to bytes
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Create a Rijndael object
            using (var rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create a memory stream with the cipher text
                using (var msDecrypt = new MemoryStream(cipherBytes))
                {
                    // Create a crypto stream to perform decryption
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        // Create a stream reader to read the decrypted data
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted data and return as plain text
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        #endregion

    }
}