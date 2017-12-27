using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawingu
{
    public class TSVHelper
    {

        public static string[] SplitCSVLine(string line)
        {
            List<string> result = new List<string>();

            string[] parts = line.Split(',');

            bool inquotes = false;
            string quotedstring = string.Empty;

            foreach (string part in parts)
            {
                if (part.StartsWith("\""))
                {
                    inquotes = true;
                    quotedstring = part;

                }
                else if (inquotes)
                {
                    quotedstring += "," + part;
                    if (part.EndsWith("\""))
                    {
                        inquotes = false;
                        result.Add(
                            quotedstring.Replace("\"", "")
                            );
                    } // Ends with

                } // In quotes
                else
                {
                    result.Add(part);

                } // else

            } // foreach

            return result.ToArray();

        }

        public static string StringByColumn(string[] colNames, string[] values, string colName)
        {
            try
            {
                int colidx = Array.IndexOf(colNames, colName);
                if (colidx >= 0 && colidx < values.Length)
                {
                    return values[colidx];

                }
                else
                {
                    return "";

                }

            }
            catch
            {
                throw;

            }

        }

        public static bool? NullableBoolByColumn(string[] colNames, string[] values, string colName)
        {
            bool? result = null;

            string val = StringByColumn(colNames, values, colName);
            if (!string.IsNullOrWhiteSpace(val))
            {
                bool b;
                if (bool.TryParse(val, out b))
                {
                    result = b;
                } // Success

            } // Got string

            return result;

        }

        public static bool BoolByColumn(string[] colNames, string[] values, string colName)
        {
            bool? val = NullableBoolByColumn(colNames, values, colName);
            return val.HasValue ? val.Value : false;

        }

        public static DateTime? NullableDateTimeByColumn(string[] colNames, string[] values, string colName)
        {
            DateTime? result = null;

            string val = StringByColumn(colNames, values, colName);
            if (!string.IsNullOrWhiteSpace(val))
            {
                DateTime dt;
                if (DateTime.TryParse(val, out dt))
                {
                    result = dt;
                } // Success

            } // Got string

            return result;

        }

        public static DateTime DateTimeByColumn(string[] colNames, string[] values, string colName)
        {
            DateTime? val = NullableDateTimeByColumn(colNames, values, colName);
            return val.HasValue ? val.Value : DateTime.MinValue;

        }

        public static double? NullableDoubleByColumn(string[] colNames, string[] values, string colName)
        {
            double? result = null;

            string val = StringByColumn(colNames, values, colName);
            if (!string.IsNullOrWhiteSpace(val))
            {
                double d;
                if (double.TryParse(val, out d))
                {
                    result = d;

                } // Success

            } // Got string

            return result;

        }

        public static double DoubleByColumn(string[] colNames, string[] values, string colName)
        {
            double? val = NullableDoubleByColumn(colNames, values, colName);
            return val.HasValue ? val.Value : 0;
            
        }

        public static int? NullableIntByColumn(string[] colNames, string[] values, string colName)
        {
            int? result = null;

            string val = StringByColumn(colNames, values, colName);
            if (!string.IsNullOrWhiteSpace(val))
            {
                int v;
                if (int.TryParse(val, out v))
                {
                    result = v;
                } // Success

            } // Got string

            return result;

        }

        public static int IntByColumn(string[] colNames, string[] values, string colName)
        {
            int? val = NullableIntByColumn(colNames, values, colName);
            return val.HasValue ? val.Value : 0;
            
        }

        public static long? NullableLongByColumn(string[] colNames, string[] values, string colName)
        {
            long? result = null;

            string val = StringByColumn(colNames, values, colName);
            if (!string.IsNullOrWhiteSpace(val))
            {
                long l;
                if (long.TryParse(val, out l))
                {
                    result = l;

                } // Success

            } // Got string

            return result;

        }

        public static long LongByColumn(string[] colNames, string[] values, string colName)
        {
            long? val = NullableLongByColumn(colNames, values, colName);
            return val.HasValue ? val.Value : 0;
        }


    }
}
