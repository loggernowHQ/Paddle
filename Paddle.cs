using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using PhpSerializerNET;
using System.ComponentModel.Design;
using System.Text;

namespace Loggernow.Paddle.Payments
{
    public class Paddle
    {
        private readonly string _publicKey;
        private readonly ILogger _logger;

        public Paddle(string publicKey,  ILogger logger = null)
        {
            _publicKey = publicKey;
            _logger = logger;
        }

        /// <summary>
        /// Verify The Paddle webhook signature
        /// </summary>
        /// <param name="req"></param>
        /// <returns>Result of vereification.True if succeeds ,false if it fails</returns>
        public bool VerifySignature( HttpRequest req)
        {

            string[] sortedKeys = req.Form.Keys.OrderBy(x => x, StringComparer.Ordinal).ToArray();
            byte[] signature = Convert.FromBase64String(req.Form["p_signature"]);
            SortedDictionary<string, object> padStuff = new SortedDictionary<string, object>();

            foreach (string key in sortedKeys)
            {
                string value = req.Form[key].ToString();
                if (key != "p_signature")
                {
                    padStuff.Add(key, value);
                }
            }
            string serializedData = PhpSerialization.Serialize(padStuff);

            return verifySignature(signature, serializedData, _publicKey);
           
        }
        private bool verifySignature(byte[] signatureBytes, string message, string publicKey)
        {
            StringReader publicKeyStringReader = new StringReader(publicKey);
            AsymmetricKeyParameter publicKeyAsym= (AsymmetricKeyParameter)new PemReader(publicKeyStringReader).ReadObject();
            ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
            sig.Init(false, publicKeyAsym);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            sig.BlockUpdate(messageBytes, 0, messageBytes.Length);
            return sig.VerifySignature(signatureBytes);
        }



    }
}