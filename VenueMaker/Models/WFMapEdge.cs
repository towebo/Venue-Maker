using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WayfindR.Models
{
    public class WFMapEdge
    {
        [XmlAttribute("start")]
        public WFMapPoint Start { get; set; }

        [XmlAttribute("end")]
        public WFMapPoint End { get; set; }

    }
}
