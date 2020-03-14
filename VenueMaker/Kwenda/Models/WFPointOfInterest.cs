using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public class WFPointOfInterest
    {
        private WFNode linkednode;


        public enum POICategory
        {
            General,
            WC,
            HWC

        } // enum

        public string Guid { get; set; }
        public string BeaconGuid { get; set; }
        public POICategory Category { get; set; }
        public WFPOIInformation[] Information { get; set; }

        public WFNode LinkedNode
        {
            get { return linkednode; }
        } // LinkedNode

        public string TextInList
        {
            get
            {
                if (linkednode == null)
                {
                    return this.Guid;

                } // Not linked

                StringBuilder result = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(LinkedNode.Floor))
                {
                    result.Append($"{LinkedNode.Floor} - {LinkedNode.Name}");

                }
                else
                {
                    result.Append(LinkedNode.Name);

                }

                if (!string.IsNullOrWhiteSpace(linkednode.IdTag))
                {
                    result.Append($" ({linkednode.IdTag})");

                } // Has tag

                if (linkednode.Active.ToLower() != "true")
                {
                    result.Append($" *** Inaktiv ***");

                } // Has tag

                return result.ToString();

            }

        }
        

        public WFPointOfInterest()
        {
            Guid = System.Guid.NewGuid().ToString();

        }

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

        public void LinkTo(WFNode node)
        {
            linkednode = node;
            BeaconGuid = linkednode.Guid;

        }

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


    }
}
