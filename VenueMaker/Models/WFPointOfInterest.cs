using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public class WFPointOfInterest
    {
        public enum POICategory
        {
            General,
            WC,
            HWC

        } // enum

        public string Name { get; set; }
        public string DescriptiveName { get; set; }

        public string BeaconUuid { get; set; }
        public int BeaconMajor { get; set; }
        public int BeaconMinor { get; set; }
        
        public POICategory Category { get; set; }

        public WFPOIInformation[] Information { get; set; }


        public static POICategory CategoryFromString(string catName)
        {
            if ("general" == catName.ToLower())
            {
                return POICategory.General;
            }
            else if ("wc" == catName.ToLower())
            {
                return POICategory.WC;
            }
            else if ("hwc" == catName.ToLower())
            {
                return POICategory.HWC;
            }

            return POICategory.General;

        }

        public WFPOIInformation[] GetCurrentInformation(DateTime theDate)
        {
            WFPOIInformation[] result = this.Information;

            if (result != null)
            {
                result = (
                    from x in this.Information
                    where (
                        (x.StartsAt == null && x.EndsAt == null) ||
                        (x.StartsAt <= theDate && x.EndsAt == null) ||
                        (x.StartsAt <= theDate && x.EndsAt >= theDate) ||
                        (x.StartsAt == null && x.EndsAt >= theDate)
                    )
                    select x
                    ).ToArray();

            }

            return result;

        }

    }
}
