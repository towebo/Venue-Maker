using System;
using System.Text;

namespace MAWINGU.Utils
{
    public static class Base64Helper
    {
        public static string EncodeBase64(this string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        public static string EncodeBase64FromBytes(this byte[] value)
        {
            if (value == null ||
                value.Length == 0)
            {
                return null;
            } // No data

            return Convert.ToBase64String(value);

        }

        public static string DecodeBase64(this string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(textAsBytes);

        }

        public static byte[] DecodeBase64ToBytes(this string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            return textAsBytes;

        }
    
    } // class


}