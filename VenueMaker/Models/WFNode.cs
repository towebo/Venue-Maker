using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace WayfindR.Models
{
    [Serializable]
    public class WFNode
    {
        private List<WFHeadingInfo> hinfos;
        private string _active;

        
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("venue_id")]
        public string VenueId { get; set; }

        [XmlAttribute("uuid")]
        public string Uuid { get; set; }


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

        [XmlAttribute("heading1info")]
        public string Heading1Info
        {
            get { return GetHeadingInfo(0); }
            set { SetHeadingInfo(0, value); }
        }

        [XmlAttribute("heading2info")]
        public string Heading2Info
        {
            get { return GetHeadingInfo(1); }
            set { SetHeadingInfo(1, value); }
        }

        [XmlAttribute("heading3info")]
        public string Heading3Info
        {
            get { return GetHeadingInfo(2); }
            set { SetHeadingInfo(2, value); }
        }

        [XmlAttribute("heading4info")]
        public string Heading4Info
        {
            get { return GetHeadingInfo(3); }
            set { SetHeadingInfo(3, value); }
        }

        [XmlAttribute("heading5info")]
        public string Heading5Info
        {
            get { return GetHeadingInfo(4); }
            set { SetHeadingInfo(4, value); }
        }

        [XmlAttribute("map_point")]
        public string MapPointStr { get; set; }

        [XmlAttribute("in_range_accuracy")]
        public double? InRangeAccuracy { get; set; }
        

        [XmlAttribute("in_range_message")]
        public string InRangeMessage { get; set; }
        

        [XmlAttribute("out_of_range_message")]
        public string OutOfRangeMessage { get; set; }

        [XmlAttribute("touch_message")]
        public string TouchMessage { get; set; }

        [XmlAttribute("close_by_accuracy")]
        public double CloseByAccuracy { get; set; }

        [XmlAttribute("close_by_message")]
        public string CloseByMessage { get; set; }


        [XmlAttribute("gpscoordinates")]
        public string GPSCoordinates { get; set; }

        [XmlAttribute("area")]
        public string Area { get; set; }

        [XmlAttribute("building")]
        public string Building { get; set; }
        
        [XmlAttribute("floor")]
        public string Floor { get; set; }

        [XmlAttribute("department")]
        public string Department { get; set; }

        [XmlAttribute("room")]
        public string Room { get; set; }

        [XmlAttribute("space")]
        public string Space { get; set; }
        
        [XmlAttribute("id_tag")]
        public string IdTag { get; set; }


		[XmlAttribute("active")]
		public string Active
        {
            get { return _active.ToLower(); }
            set { _active = value.ToLower(); }
        }

        [XmlAttribute("magnetic_offset")]
        public int MagneticOffset { get; set; }


        public string TextInList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Floor))
                {
                    return string.Format("{0} - {1}",
                        this.Floor,
                        this.Name
                        );
                }
                else
                {
                    return this.Name;

                }
            }


        }

        public WFHeadingInfo[] HeadingInfos
        {
            get
            {
                return hinfos.ToArray();
            }
            set
            {
                hinfos = value.ToList();
            }

        } // HeadingInfos

        public WFMapPoint MapPoint
        {
            get
            {
                return WFMapPoint.FromString(MapPointStr);
            } // get
            set
            {
                MapPointStr = value.ToString();

            } // set
        } // MapPoint


        public WFNode()
            : this("")
        {
        }

        public WFNode(string id)
        {
            hinfos = new List<WFHeadingInfo>();
            this.Id = id;

        }




        private string GetHeadingInfo(int idx)
        {
            string result = string.Empty;
            if (idx < hinfos.Count)
            {
                result = HeadingInfos[idx].ToString();

            }

            return result;

        }

        private void SetHeadingInfo(int idx, string data)
        {
            WFHeadingInfo hi = new WFHeadingInfo(data);
            while (idx >= hinfos.Count)
            {
                hinfos.Add(new WFHeadingInfo());

            }
            hinfos[idx] = hi;
                
        }


    }
}
