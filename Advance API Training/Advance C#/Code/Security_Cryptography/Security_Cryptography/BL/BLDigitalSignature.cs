using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography.BL
{
    /// <summary>
    /// Contains methods for generating and verifying digital signatures.
    /// </summary>
    public class BLDigitalSignature
    {
        /// <summary>
        /// Generates a digital signature for the provided data.
        /// </summary>
        /// <param name="data">Data for which to generate the signature.</param>
        /// <returns>Generated digital signature.</returns>
        public byte[] GenerateSignature(string data)
        {
            // Create a new instance of RSACryptoServiceProvider
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Export the private key as XML
                string privateKey = rsa.ToXmlString(true);

                // Import the private key
                rsa.FromXmlString(privateKey);

                // Convert data to bytes
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                // Generate digital signature using SHA256 hashing algorithm
                return rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());
            }
        }

        /// <summary>
        /// Verifies the digital signature for the provided data.
        /// </summary>
        /// <param name="data">Data for which to verify the signature.</param>
        /// <param name="signature">Digital signature to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public bool VerifySignature(string data, byte[] signature)
        {
            // Create a new instance of RSACryptoServiceProvider
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Export the public key as XML
                string publicKey = rsa.ToXmlString(false);

                // Import the public key
                rsa.FromXmlString(publicKey);

                // Convert data to bytes
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                // Verify digital signature using SHA256 hashing algorithm
                return rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signature);
            }
        }
    }
}
