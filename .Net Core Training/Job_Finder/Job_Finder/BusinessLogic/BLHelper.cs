﻿using System.Security.Cryptography;
using System.Text;

namespace Job_Finder.BusinessLogic
{
    public class BLHelper
    {
        #region Private member

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("ThisIsASecretKey1234567890123456"); // 256-bit key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 128-bit IV

        #endregion


        public Tpoco Map<Tdto, Tpoco>( Tdto source) where Tpoco : new()
        {
            var target = new Tpoco();

            // Iterate over properties of the source object
            foreach (var sourceProperty in typeof(Tdto).GetProperties())
            {
                // Find corresponding property in the target object
                var targetProperty = typeof(Tpoco).GetProperty(sourceProperty.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    if (value != null)
                    {
                        // Check if the property types are compatible or assignable
                        if (targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            targetProperty.SetValue(target, value);
                        }
                        else
                        {
                            // Try converting the value to the target property type
                            var convertedValue = Convert.ChangeType(value, targetProperty.PropertyType);
                            targetProperty.SetValue(target, convertedValue);
                        }
                    }
                }
            }

            return target;
        }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // Replace "DefaultConnection" with the key used in appsettings.json for your connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }

        /// <summary>
        /// Encrypts the input plain text using Rijndael encryption.
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted.</param>
        /// <returns>The Base64-encoded ciphertext.</returns>
        public string Encrypt(string plainText)
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
        public string Decrypt(string cipherText)
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

    }
}
