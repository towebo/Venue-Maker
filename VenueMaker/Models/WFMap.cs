using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public enum WFMapType
    {
        Jpg = 0
    } // Enum

    public class WFMap
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string FileName { get; set; }
        public WFMapType MapType { get; set; }

    } // class
}
