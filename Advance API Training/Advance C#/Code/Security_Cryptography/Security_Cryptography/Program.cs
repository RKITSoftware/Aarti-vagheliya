using Security_Cryptography.BL;
using System;

namespace Security_Cryptography
{
    /// <summary>
    /// Represents a console application to demonstrate various cryptographic operations.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //instance of BLRijndael class
            BLRijndael objBLRijndael = new BLRijndael();

            //instance of BLAES class
            BLAES objBLAES = new BLAES();

            //instance of BLRSA class
            BLRSA objBLRSA = new BLRSA();

            //instance of BLHashing class
            BLHashing objBLHashing = new BLHashing();

            //instance of BLDigitalSignature class
            BLDigitalSignature objBLDigitalSignature = new BLDigitalSignature();


            // Input from user
            Console.WriteLine("Enter words: ");
            string originalText = Console.ReadLine();//"Hello, world!";
            Console.WriteLine("Original Text: " + originalText);
            Console.WriteLine();


            // Symmetric Encryption and Decryption using AES algorithm
            #region AES Encryption and Decryption

            Console.WriteLine("AES Encryption and Decryption:");
            string encryptedAES = objBLAES.Encrypt(originalText); // Encrypt input using AES
            Console.WriteLine("Encrypted Text (AES): " + encryptedAES);
            string decryptedAES = objBLAES.Decrypt(encryptedAES); // Decrypt AES-encrypted text
            Console.WriteLine("Decrypted Text (AES): " + decryptedAES);
            Console.WriteLine();

            #endregion

            // Hashing using SHA256 algorithm
            #region SHA256 Hashing

            Console.WriteLine("Hashing using SHA256:");
            string hashedText = objBLHashing.ComputeSHA256Hash(originalText); // Compute SHA256 hash
            Console.WriteLine("Hashed Text (SHA256): " + hashedText);
            Console.WriteLine();

            #endregion 

            // Digital Signature using RSA algorithm
            #region RSA Digital Signature

            Console.WriteLine("Digital Signature using RSA:");
            byte[] signature = objBLDigitalSignature.GenerateSignature(originalText); // Generate RSA digital signature
            bool isValidSignature = objBLDigitalSignature.VerifySignature(originalText, signature); // Verify RSA signature
            Console.WriteLine("Is Signature Valid: " + isValidSignature);
            Console.WriteLine();

            #endregion

            //  Rijndael Encryption and Decryption
            #region Rijndael Encryption and Decryption

            Console.WriteLine("Rijndael Encryption and Decryption:");
            Console.WriteLine("Original Text: " + originalText);
            string encryptedText = objBLRijndael.Encrypt(originalText); // Encrypt input using Rijndael
            Console.WriteLine("Encrypted Text (Rijndael): " + encryptedText);
            string decryptedText = objBLRijndael.Decrypt(encryptedText); // Decrypt Rijndael-encrypted text
            Console.WriteLine("Decrypted Text (Rijndael): " + decryptedText);
            Console.WriteLine();

            #endregion

            // Encrypt and decrypt using RSA
            #region RSA Encryption and Decryption

            Console.WriteLine("RSA Encryption and Decryption:");
            string encryptedRSA = objBLRSA.EncryptedByRSA(originalText); // Encrypt input using RSA
            Console.WriteLine("Encrypted Text (RSA): " + encryptedRSA);
            string decryptedRSA = objBLRSA.DecryptByRSA(encryptedRSA); // Decrypt RSA-encrypted text
            Console.WriteLine("Decrypted Text (RSA): " + decryptedRSA);

            #endregion

        }
    }
}
