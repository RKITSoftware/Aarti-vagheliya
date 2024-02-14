using Security_Cryptography.BL;
using System;

namespace Security_Cryptography
{
    /// <summary>
    /// Represents a console application to demonstrate various cryptographic operations.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Input

            // Input from user
            Console.WriteLine("Enter words: ");
            string originalText = Console.ReadLine();//"Hello, world!";
            Console.WriteLine("Original Text: " + originalText);
            Console.WriteLine();

            #endregion

            // Symmetric Encryption and Decryption using AES algorithm
            #region AES Encryption and Decryption

            Console.WriteLine("AES Encryption and Decryption:");
            string encryptedAES = BLAES.Encrypt(originalText); // Encrypt input using AES
            Console.WriteLine("Encrypted Text (AES): " + encryptedAES);
            string decryptedAES = BLAES.Decrypt(encryptedAES); // Decrypt AES-encrypted text
            Console.WriteLine("Decrypted Text (AES): " + decryptedAES);
            Console.WriteLine();

            #endregion

            // Hashing using SHA256 algorithm
            #region SHA256 Hashing

            Console.WriteLine("Hashing using SHA256:");
            string hashedText = BLHashing.ComputeSHA256Hash(originalText); // Compute SHA256 hash
            Console.WriteLine("Hashed Text (SHA256): " + hashedText);
            Console.WriteLine();

            #endregion 

            // Digital Signature using RSA algorithm
            #region RSA Digital Signature

            Console.WriteLine("Digital Signature using RSA:");
            byte[] signature = BLDigitalSignature.GenerateSignature(originalText); // Generate RSA digital signature
            bool isValidSignature = BLDigitalSignature.VerifySignature(originalText, signature); // Verify RSA signature
            Console.WriteLine("Is Signature Valid: " + isValidSignature);
            Console.WriteLine();

            #endregion

            //  Rijndael Encryption and Decryption
            #region Rijndael Encryption and Decryption

            Console.WriteLine("Rijndael Encryption and Decryption:");
            Console.WriteLine("Original Text: " + originalText);
            string encryptedText = BLRijndael.Encrypt(originalText); // Encrypt input using Rijndael
            Console.WriteLine("Encrypted Text (Rijndael): " + encryptedText);
            string decryptedText = BLRijndael.Decrypt(encryptedText); // Decrypt Rijndael-encrypted text
            Console.WriteLine("Decrypted Text (Rijndael): " + decryptedText);
            Console.WriteLine();

            #endregion

            // Encrypt and decrypt using RSA
            #region RSA Encryption and Decryption

            Console.WriteLine("RSA Encryption and Decryption:");
            string encryptedRSA = BLRSA.EncryptedByRSA(originalText); // Encrypt input using RSA
            Console.WriteLine("Encrypted Text (RSA): " + encryptedRSA);
            string decryptedRSA = BLRSA.DecryptByRSA(encryptedRSA); // Decrypt RSA-encrypted text
            Console.WriteLine("Decrypted Text (RSA): " + decryptedRSA);

            #endregion





        }
    }
}
