using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security_Cryptography.BL
{
    public class BLRSA
    {
        public static string Encrypt(string plainText)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                rsa.FromXmlString(publicKey);
                byte[] cipherBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), true);
                return Convert.ToBase64String(cipherBytes);
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                string privateKey = rsa.ToXmlString(true);
                rsa.FromXmlString(privateKey);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] plainBytes = rsa.Decrypt(cipherBytes, true);
                return Encoding.UTF8.GetString(plainBytes);
            }
        }
    }
}
