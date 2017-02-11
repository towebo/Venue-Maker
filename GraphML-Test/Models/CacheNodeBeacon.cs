using SQLite;

namespace WayfindR.Models
{
    [Table("CacheNodeBeacons")]
	public class CacheNodeBeacon
	{		
        [Indexed(Name = "MajorMinor", Order = 1)]
        public int Major { get; set; }
        [Indexed(Name = "MajorMinor", Order = 2)]
        public int Minor { get; set; }
		public double? Distance { get; set; }

        public string GraphId { get; set; }
        public int GraphLevel { get; set; }
        public string VenueId { get; set; }




	}
}
