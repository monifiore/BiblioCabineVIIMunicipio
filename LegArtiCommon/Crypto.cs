using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LegArtiCommon
{
    public class Crypto
    {
        /// <summary>
        /// Chiave utilizzata per il cripting e decripting
        /// </summary>
        private static string _key = "b14ca5898a4e4133bbce2ea2315a1916";
        public Crypto()
        {
        }
        public Crypto(string key)
        {
            _key = key;
        }
        public string Encrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                try
                {
                    while (_key.Length < 32) _key += "0";
                    aes.Key = Encoding.UTF8.GetBytes(_key);
                }
                catch (Exception)
                {
                    aes.Key = Encoding.UTF8.GetBytes(_key).Take(32).ToArray();
                }
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using MemoryStream memoryStream = new();
                using CryptoStream cryptoStream = new((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new((Stream)cryptoStream))
                {
                    streamWriter.Write(text);
                }
                array = memoryStream.ToArray();
            }
            return Convert.ToBase64String(array);
        }
        public string Decrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);
            using Aes aes = Aes.Create();
            try
            {
                while (_key.Length < 32) _key += "0";
                aes.Key = Encoding.UTF8.GetBytes(_key);
            }
            catch (Exception)
            {
                aes.Key = Encoding.UTF8.GetBytes(_key).Take(32).ToArray();
            }
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new((Stream)cryptoStream);
            return streamReader.ReadToEnd();
        }

    }
}
