﻿using System;

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