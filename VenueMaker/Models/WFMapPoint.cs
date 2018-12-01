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

    } // class
}
