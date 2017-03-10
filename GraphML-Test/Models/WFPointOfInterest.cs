using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public class WFPointOfInterest
    {
        public enum Category
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


        public WFPOIInformation[] Information { get; set; }


        public Category CategoryFromString(string catName)
        {
            if ("general" == catName.ToLower())
            {
                return Category.General;
            }
            else if ("wc" == catName.ToLower())
            {
                return Category.WC;
            }
            else if ("hwc" == catName.ToLower())
            {
                return Category.HWC;
            }

            return Category.General;

        }


    }
}
