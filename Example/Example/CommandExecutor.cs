using System.Net;

namespace Example
{
    public class CommandExecutor
    {
        /// <summary>
        /// Unsafe demonstration method
        /// </summary>
        /// <param name="path"></param>
        public void Start(string path)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}