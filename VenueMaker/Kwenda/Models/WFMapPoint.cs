using Kwenda;
using Mawingu;
using MAWINGU.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WayfindR.Models
{
    public class WFMapPoint
    {
        [XmlAttribute("map_id")]
        public string MapId { get; set; }

        [XmlAttribute("x")]
        public double X { get; set; }

        [XmlAttribute("y")]
        public double Y { get; set; }


        public static WFMapPoint FromString(string str)
        {
            WFMapPoint result = new WFMapPoint();

            if (!string.IsNullOrWhiteSpace(str))
            {
                string[] parts = str.Split(',');

                if (parts.Length > 0)
                {
                    result.MapId = parts[0];

                } // Has map
                if (parts.Length > 1)
                {
                    result.X = double.Parse(parts[1]);

                } // Has X
                if (parts.Length > 2)
                {
                    result.Y = double.Parse(parts[2]);

                } // Has Y

            } // str not null

            return result;

        }

        public static WFMapPoint[] ArrayFromString(string str)
        {
            try
            {
                List<WFMapPoint> result = new List<WFMapPoint>();
                if (string.IsNullOrWhiteSpace(str))
                {
                    return result.ToArray();

                } // Empty string

                string[] parts = str.Split('|');
                foreach (string part in parts)
                {
                    result.Add(WFMapPoint.FromString(part));

                } // foreach

                return result.ToArray();

            }
            catch (Exception ex)
            {
                string errmsg = $"WFMapPoint.ArrayFromString({str}): {ex.Message}";
                LogCenter.Error(
                    $"WFMapPoint.ArrayFromString({str})",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }

        }

        public new string ToString()
        {
            string result = $"{MapId},{X.ToString().Replace(",", ".")},{Y.ToString().Replace(",", ".")}";
            return result;

        }

        public static string ArrayToString(WFMapPoint[] items)
        {
            try
            {
                StringBuilder result = new StringBuilder();

                foreach (WFMapPoint item in items)
                {
                    result.Append(
                        item.ToString()
                        );
                    result.Append("|");

                } // foreach

                return result.ToString();

            }
            catch (Exception ex)
            {
                string errmsg = $"WFMapPoint.ArrayToStringh: {ex.Message}";
                LogCenter.Error("WFMapPoint.ArrayToString", ex.Message);
                throw new Exception(errmsg);

            }
        }



    } // class
}
