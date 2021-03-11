using System;
using System.Security.Cryptography;
using System.Text;

namespace Example.Extensions
{
    public static class CryptoStreamExtensions
    {
        /// <summary>
        /// Writes a string to a CryptoStream and flushes the data
        /// </summary>
        /// <param name="cryptoStream"></param>
        /// <param name="input"></param>
        public static void WriteUtf8String(this CryptoStream cryptoStream, string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
        }

        public static void WriteBase64String(this CryptoStream cryptoStream, string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
        } 
    }
}