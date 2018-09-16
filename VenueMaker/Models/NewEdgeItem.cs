using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace VenueMaker.Models
{
    public class NewEdgeItem
    {
        public WFNode Source { get; set; }
        public WFNode Target { get; set; }
        public string Beginning { get; set; }
        public int StartHeading { get; set; }
        public int EndHeading { get; set; }
        public int TravelTime { get; set; }
        public string TravelType { get; set; }
        
    }
}
