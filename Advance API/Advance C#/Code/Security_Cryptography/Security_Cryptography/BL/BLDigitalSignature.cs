using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security_Cryptography.BL
{
    public class BLDigitalSignature
    {
        public static byte[] GenerateSignature(string data)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                string privateKey = rsa.ToXmlString(true);
                rsa.FromXmlString(privateKey);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                return rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());
            }
        }

        public static bool VerifySignature(string data, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                rsa.FromXmlString(publicKey);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                return rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signature);
            }
        }
    }
}
