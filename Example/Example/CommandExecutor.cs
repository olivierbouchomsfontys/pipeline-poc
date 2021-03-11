using System.Diagnostics;
using System.Net;
using System.Xml;

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
            var doc = new XmlDocument {XmlResolver = null};
            doc.Load("/config.xml");
            var results = doc.SelectNodes("/Config/Devices/Device[id='" + path + "']");
            
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            
            var process = new Process();
            
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "START " + path;
            
            process.Start();
        }
    }
}