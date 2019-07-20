using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawingu
{
    public static class UrlHelper
    {
        public static string AddToUrl(this string url, string str)
        {
            if (url == null)
            {
                return str;

            } // Is null

            StringBuilder result = new StringBuilder(url);
            if (!url.EndsWith("/"))
            {
                result.Append("/");

            } // Lacks the ending slash

            result.Append(str);

            return result.ToString();

        }



    }
}
