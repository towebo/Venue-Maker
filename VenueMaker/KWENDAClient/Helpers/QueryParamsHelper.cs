using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KWENDA.Helpers
{
    public static class QueryParamsHelper
    {

        public static string AsQueryString(this string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;

            } // No value

            var query = HttpUtility.ParseQueryString("");
            query[paramName] = value;

            return query.ToString();

        }

    }
}
