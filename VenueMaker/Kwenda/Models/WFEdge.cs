using QuickGraph;
using System;
using System.Xml.Serialization;

namespace WayfindR.Models
{   
    [Serializable]
    public class WFEdge<TVertex> : Edge<TVertex>
    {
        public string Id { get; set; }

        [XmlAttribute("guid")]
        public string Guid { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("travel_time")]
        public double TravelTime { get; set; }

        [XmlAttribute("language")]        
        public string Language { get; set; }

        [XmlAttribute("beginning")]
        public string Beginning { get; set; }

        [XmlAttribute("middle")]
        public string Middle { get; set; }

        [XmlAttribute("ending")]
        public string Ending { get; set; }

        [XmlAttribute("starting_only")]
        public string StartingOnly { get; set; }

        [XmlAttribute("start_heading")]
        public int StartHeading { get; set; }

        [XmlAttribute("end_heading")]
        public int EndHeading { get; set; }

        [XmlAttribute("travel_type")]
        public string TravelType { get; set; }

        [XmlAttribute("map_points")]
        public string MapPointsStr { get; set; }

        public WFMapPoint[] MapPoints
        {
            get
            {
                return WFMapPoint.ArrayFromString(MapPointsStr);

            } // get
            set
            {
                MapPointsStr = WFMapPoint.ArrayToString(value);

            } // set
        } // MapPoints

        public WFNode Start
        {
            get { return this.Source as WFNode; }
        } // Source
        public WFNode Destination
        {
            get { return this.Target as WFNode; }
        } // Destination

        public string FullDescription
        {
            get
            {
                WFNode src = this.Source as WFNode;

                return string.Format("{0}, {1}, {2}, {3}",
                    src.Name,
                    Beginning,
                    Middle,
                    Ending
                    );
            }
        }


        public WFEdge(TVertex source, TVertex target, string id)
            : base(source, target)
        {
            Id = id;
            Guid = System.Guid.NewGuid().ToString();

        }
    }


}
