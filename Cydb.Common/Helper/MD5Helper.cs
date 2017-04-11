using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cydb.Common.Helper {
    /// <summary>
    /// Summary description for MD5Helper
    /// </summary>
    public class MD5Helper {
        /// <summary>
        /// MD5 16位加密
        /// </summary>
        /// <param name="convertString"></param>
        /// <returns></returns>
        public static string Md5_16Bit(string convertString) {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(convertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5_32Bit(string str) {
            string cl = str;
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return s.Aggregate("", (current, t) => current + t.ToString("X"));
        }
    }
}