using Loggernow.Paddle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using PhpSerializerNET;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace Loggernow.Paddle.Payments
{
    public partial class Paddle
    {
        private readonly string _publicKey;
        private readonly ILogger _logger;

        private HttpRequest _req;

        public Paddle(string publicKey,  ILogger logger )
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
            _req=req;
            string[] sortedKeys = _req.Form.Keys.OrderBy(x => x, StringComparer.Ordinal).ToArray();
            byte[] signature = Convert.FromBase64String(_req.Form["p_signature"]);
            SortedDictionary<string, object> padStuff = new SortedDictionary<string, object>();

            foreach (string key in sortedKeys)
            {
                string value = _req.Form[key].ToString();
                if (key != "p_signature")
                {
                    padStuff.Add(key, value);
                }
            }
            string serializedData = PhpSerialization.Serialize(padStuff);

            StringReader publicKeyStringReader = new StringReader(_publicKey);
            AsymmetricKeyParameter publicKeyAsym = (AsymmetricKeyParameter)new PemReader(publicKeyStringReader).ReadObject();
            ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
            sig.Init(false, publicKeyAsym);
            byte[] messageBytes = Encoding.UTF8.GetBytes(serializedData);
            sig.BlockUpdate(messageBytes, 0, messageBytes.Length);
            return sig.VerifySignature(signature);

        }

        /// <summary>
        /// takes in optional <c>HttpRequest</c>  param if not already provided and return PaddleWebhook Obj.
        /// </summary>
        /// <param name="req"></param>
        /// <returns>PaddleWebhook model</returns>
        /// <exception cref="Exception">Throws error if HttpRequest filed is not set in class</exception>
        public PaddleWebhook ParsePaddleWebhook([Optional] HttpRequest req)
        {
            if (req == null && _req!=null)
            {
                return new PaddleWebhook(_req);
            }
            else if(req!=null && req!=null)
            {
                return new PaddleWebhook(req);
            }
            else
            {
                _logger.LogError("HttpRequest field was not initialised in Paddle class");
                throw new Exception("HttpRequest not initialised");
            }
        }


         



    }
}