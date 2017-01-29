using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WayfindR.Models
{
    [Serializable]
    public class WFNode
    {
        public string Id { get; set; }

        [XmlAttribute("venue_id")]
        public string VenueId { get; set; }

        [XmlAttribute("major")]
        public int Major { get; set; }

        [XmlAttribute("minor")]
        public int Minor { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("name_descriptive")]
        public string DescriptiveName { get; set; }

        [XmlAttribute("waypoint_type")]
        public string WaypointType { get; set; }

        [XmlAttribute("accuracy")]
        public double Accuracy { get; set; }


        public WFNode(string id)
        {
            this.Id = id;

        }


    }
}
