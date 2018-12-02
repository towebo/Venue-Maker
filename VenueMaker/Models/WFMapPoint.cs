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

        public string ToString()
        {
            string result = $"{MapId},{X.ToString().Replace(",", ".")},{Y.ToString().Replace(",", ".")}";
            return result;

        }


    } // class
}
