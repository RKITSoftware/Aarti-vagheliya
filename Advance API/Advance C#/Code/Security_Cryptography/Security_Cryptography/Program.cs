using Security_Cryptography.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalText = "Hello, world!";
            Console.WriteLine("Original Text: " + originalText);

            // Symmetric Encryption and Decryption using AES algorithm
            string encryptedAES = BLAES.Encrypt(originalText);
            Console.WriteLine("Encrypted Text (AES): " + encryptedAES);
            string decryptedAES = BLAES.Decrypt(encryptedAES);
            Console.WriteLine("Decrypted Text (AES): " + decryptedAES);

            // Asymmetric Encryption and Decryption using RSA algorithm
            string encryptedRSA = BLRSA.Encrypt(originalText);
            Console.WriteLine("Encrypted Text (RSA): " + encryptedRSA);
            string decryptedRSA = BLRSA.Decrypt(encryptedRSA);
            Console.WriteLine("Decrypted Text (RSA): " + decryptedRSA);

            // Hashing using SHA256 algorithm
            string hashedText = BLHashing.ComputeSHA256Hash(originalText);
            Console.WriteLine("Hashed Text (SHA256): " + hashedText);

            // Digital Signature using RSA algorithm
            byte[] signature = BLDigitalSignature.GenerateSignature(originalText);
            bool isValidSignature = BLDigitalSignature.VerifySignature(originalText, signature);
            Console.WriteLine("Is Signature Valid: " + isValidSignature);



            //#region AES
            //var key = "b14ca5898a4e4133bbce2ea2315a1916";

            ////Console.WriteLine("Please enter a secret key for the symmetric algorithm.");
            ////var key = Console.ReadLine();

            //Console.WriteLine("Please enter a string for encryption");
            //var str = Console.ReadLine();
            //var encryptedString = BLAES.EncryptString(key, str);
            //Console.WriteLine($"encrypted string = {encryptedString}");

            //var decryptedString = BLAES.DecryptString(key, encryptedString);
            //Console.WriteLine($"decrypted string = {decryptedString}");

            //Console.ReadKey();

            //#endregion

            //string originalText = "Hello, world!";
            Console.WriteLine("Original Text: " + originalText);

            string encryptedText = BLRijndael.Encrypt(originalText);
            Console.WriteLine("Encrypted Text: " + encryptedText);

            string decryptedText = BLRijndael.Decrypt(encryptedText);
            Console.WriteLine("Decrypted Text: " + decryptedText);
        }
    }
}
