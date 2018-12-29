using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Columbo.Shared.Api.Extensions
{
    public static class StringExtension
    {
        public static string Sha256(this string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
