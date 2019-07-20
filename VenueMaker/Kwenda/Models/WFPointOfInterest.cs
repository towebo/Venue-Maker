﻿using System;
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
        public string Building { get; set; }
        public string Floor { get; set; }
        public int FloorOrdinal { get; set; }


        public void ResetAutoPlayFlags()
		{
			if (this.Information == null)
			{
				return;

			} // No information

			foreach (WFPOIInformation poii in this.Information)
			{
				poii.AlreadyAutoPlayed = false;

			} // forea   }

		}

        public string TextInList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Floor))
                {
                    return string.Format("{0} - {1}",
                        Floor,
                        Name
                        );

                }

                return string.Format("{0} ({1})",
                    Name,
                    BeaconMinor
                    );
            }
        }

        
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
                    where
                        (
                            (x.StartsAt == null && x.EndsAt == null) ||
                            (x.StartsAt <= theDate && x.EndsAt == null) ||
                            (x.StartsAt <= theDate && x.EndsAt >= theDate) ||
                            (x.StartsAt == null && x.EndsAt >= theDate)
                        ) &&
                        POIInfoCategoryPreferences.Me.ShouldDisplay(x.Category)
                    select x
                ).ToArray();

            } // Not null

            return result;

        }

    }
}
