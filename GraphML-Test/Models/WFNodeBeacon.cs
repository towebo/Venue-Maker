using System;
namespace WayfindR.Models
{
	public class WFNodeBeacon
	{

		public string Uuid { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public double? Distance { get; set; }

        public string GraphId { get; set; }




	}
}
