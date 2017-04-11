using System;
using System.IO;
using System.Security.Cryptography;

namespace Cydb.Common.Helper {
    /// <summary>
    /// DES加密
    /// </summary>
    public static class DESHelper {
        const string KEY_64 = "VavicApp";   //注意了，是8个字符，64位
        const string IV_64 = "VavicApp";
        public static string Encode(string data) {
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.Encoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        public static string Decode(string data) {
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.Encoding.ASCII.GetBytes(IV_64);
            byte[] byEnc;
            try {
                byEnc = Convert.FromBase64String(data);
            }
            catch {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
    }
}