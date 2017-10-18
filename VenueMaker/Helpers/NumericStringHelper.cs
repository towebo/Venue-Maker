namespace WayfindR.Helpers
{
    using System.Text;
    using System.Text.RegularExpressions;

    public static class NumericStringHelper
    {
        private static Regex numr;
        private static Regex alphar;

        public static Regex NumericRegex
        {
            get
            {
                if (numr == null)
                {
                    numr = new Regex(@"[\d]+");
                }

                return numr;
            }
        }

        public static Regex AlphaRegex
        {
            get
            {
                if (alphar == null)
                {
                    alphar = new Regex(@"[^\d]+");
                }

                return alphar;
            }
        }


        public static bool IsNumeric(this string thestring)
        {
            return NumericRegex.IsMatch(thestring ?? string.Empty);
        }

        public static string AlphaOnly(this string value)
        {
            return NumericRegex.Replace(value, "");
            
        }

        public static string NumbersOnly(this string value)
        {
            return AlphaRegex.Replace(value, "");

        }

    }
}