using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafPayload
{
    internal static class EncodingUtils
    {
        internal static string ToBase64(string intput)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(intput));
        }

        internal static string ToHex(string intput)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in Encoding.Default.GetBytes(intput))
            {
                stringBuilder.Append($"{b:X2} ");
            }
            return stringBuilder.ToString();
        }
    }
}
