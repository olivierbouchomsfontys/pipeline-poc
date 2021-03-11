using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Example.Extensions;

namespace Example
{
    public class AesTransformer : ITransformer
    {
        private object obj;

        public string Encrypt(string input, out string key, out string iv)
        {
            Aes aes = Aes.Create();

            key = Convert.ToBase64String(aes.Key);
            iv = Convert.ToBase64String(aes.IV);

            using MemoryStream outputStream = new();
            using ICryptoTransform transform = aes.CreateEncryptor();
            using CryptoStream cryptoStream = new(outputStream, transform, CryptoStreamMode.Write);

            cryptoStream.WriteUtf8String(input);

            byte[] bytes = outputStream.ToArray();
            
            string cipherText = Convert.ToBase64String(bytes, 0, bytes.Length);

            return cipherText;
        }

        public string Decrypt(string input, string key, string iv)
        {
            Aes aes = new AesManaged();
            
            aes.BlockSize = 128;
            aes.KeySize = 256;

            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using MemoryStream memoryStream = new();
            using ICryptoTransform transform = aes.CreateDecryptor();
            using CryptoStream cryptoStream = new (memoryStream, transform, CryptoStreamMode.Write);
            
            cryptoStream.WriteBase64String(input);
            
            byte[] bytes = memoryStream.ToArray();
            
            string cipherText = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            return cipherText;
        }
    }
}