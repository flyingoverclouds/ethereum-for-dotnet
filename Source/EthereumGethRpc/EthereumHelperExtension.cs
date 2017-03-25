using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc
{
    public static class EthereumHelperExtension
    {
        /// <summary>
        /// Encode a string in a HEX representation : 0x00112233445566778899AABBCCDDEEFF
        /// Chars are encoding using the UnicodeUTF8 text encoder (16bits per char).
        /// </summary>
        /// <param name="s">string to encode</param>
        /// <returns>hec encoded string</returns>
        public static string ToHex(this string s)
        {
            StringBuilder hexStr = new StringBuilder();
            hexStr.Append("0x");
            var enc = new UTF8Encoding();
            foreach (byte b in enc.GetBytes(s))
            {
                hexStr.AppendFormat("{0:X2}", b);
            }
            return hexStr.ToString();
        }

        /// <summary>
        /// Decode a HEX string (0x00......) to their text representation , using UnicodeUTF8 encoding (16bits pers char)
        /// Throw ArgumentException if hxstring is null, empty, not start with 0x, or size not 2 multiple.
        /// </summary>
        /// <param name="hexStr">hexstring to decode</param>
        /// <returns>decoded string (UTF8 encoded)</returns>
        public static string FromHex(this string hexStr)
        {
            if (hexStr == null)
                throw new ArgumentException("'hexstr' cannot be null");
            if (!hexStr.StartsWith("0x"))
                throw new ArgumentException("'hexstr' does not start with '0x'");
            if (hexStr.Length % 2 != 0)
                throw new ArgumentException("'hexstr' invalid size");

            byte[] buffer = new byte[(hexStr.Length - 2) / sizeof(char)];
            for (int n = 1; n < hexStr.Length / 2; n++)
                buffer[n - 1] = Convert.ToByte(hexStr.Substring(n * 2, 2), 16);
            var enc = new UTF8Encoding();
            var str = enc.GetString(buffer);
            return str;

        }

    }
}
