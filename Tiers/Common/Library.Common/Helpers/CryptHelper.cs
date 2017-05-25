using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Common.Helpers
{
    public static class CryptHelper
    {
        public static string HashMd5(this string str)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(str);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
                // without dashes
                .Replace("-", string.Empty)
                // make lowercase
                .ToLower();

            return encoded;
        }
    }
}
