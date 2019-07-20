﻿using SQLite;

namespace WayfindR.Models
{
    [Table("CacheNodeBeacons")]
	public class CacheNodeBeacon
	{		
        [Indexed]
        public string Uuid { get; set; }

        [Indexed(Name = "MajorMinor", Order = 1)]
        public int Major { get; set; }
        [Indexed(Name = "MajorMinor", Order = 2)]
        public int Minor { get; set; }
		public double? Distance { get; set; }
        
        public string GraphId { get; set; }
        public int GraphLevel { get; set; }
        public string VenueId { get; set; }

        public string VenueName { get; set; }
        public string NodeName { get; set; }
        public string WaypointType { get; set; }


        [Ignore]
        public WFNode Node { get; set; }
        [Ignore]
        public WFGraph Graph { get; set; }
        [Ignore]
        public WFVenue Venue { get; set; }
        [Ignore]
        public BLEBeacon Beacon { get; set; }




    }
}