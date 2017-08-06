using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public class WFPOIInformation
    {
        public enum InfoCategory
        {
            Description,
            Interior,
            OpeningHours,
            Offer
        }


        public string Information { get; set; }
        public InfoCategory Category { get; set; }
        public string MediaFile { get; set; }
        public string MediaDescription { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }


        public InfoCategory CategoryFromString(string catName)
        {
            try
            {
                if ("description" == catName.ToLower())
                {
                    return InfoCategory.Description;
                }
                else if ("interior" == catName.ToLower())
                {
                    return InfoCategory.Interior;
                }
                else if ("openinghours" == catName.ToLower())
                {
                    return InfoCategory.OpeningHours;
                }
                else if ("offer" == catName.ToLower())
                {
                    return InfoCategory.Offer;
                }

                return InfoCategory.Description;

            }
            catch
            {
                return InfoCategory.Description;

            }

        }

    }
}
