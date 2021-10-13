using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Extension
{
    static public partial class Extension
    {
        public static string ToMd5(this string text)
        {
            using (var provider = new MD5CryptoServiceProvider())
            {
                byte[] textbuffer = Encoding.UTF8.GetBytes(text);
                byte[] buffertext = provider.ComputeHash(textbuffer);

                StringBuilder sb = new StringBuilder();
                foreach (var Hashedbyte in buffertext)
                {
                    sb.Append(Hashedbyte.ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static string Encrypt(this string text, string key)
        {
            try
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keyBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"@{key}!"));
                    var ivBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"#{key}%"));
                    var transform = tdes.CreateEncryptor(keyBuffer, ivBuffer);

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        byte[] txt = Encoding.UTF8.GetBytes(text);
                        cs.Write(txt, 0, txt.Length);
                        cs.FlushFinalBlock();
                        ms.Position = 0;
                        byte[] result = new byte[ms.Length];
                        ms.Read(result, 0, result.Length);
                        return Convert.ToBase64String(result);
                    }
                }
            }
            catch (Exception )
            {
                return "";
            }
        }
        public static string Decrypt(this string text, string key)
        {
            try
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keyBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"@{key}!"));
                    var ivBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"#{key}%"));
                    var transform = tdes.CreateDecryptor(keyBuffer, ivBuffer);

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        byte[] txt = Convert.FromBase64String(text);
                        cs.Write(txt, 0, txt.Length);
                        cs.FlushFinalBlock();
                        ms.Position = 0;
                        byte[] result = new byte[ms.Length];
                        ms.Read(result, 0, result.Length);
                        return Encoding.UTF8.GetString(result);
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
