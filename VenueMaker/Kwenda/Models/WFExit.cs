using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public class WFExit
    {
        public string Name { get; set; }
        public int EntranceBeaconMajor { get; set; }
        public int EntranceBeaconMinor { get; set; }
        public int ExitBeaconMajor { get; set; }
        public int ExitBeaconMinor { get; set; }
        public string Mode { get; set; }


    }
}
