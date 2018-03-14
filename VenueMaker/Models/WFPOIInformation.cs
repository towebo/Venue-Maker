using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public enum WFInfoCategory
    {
        Description,
        Interior,
        OpeningHours,
        Offer
    } // enum

    public class WFPOIInformation
    {
        public string Information { get; set; }
        public WFInfoCategory Category { get; set; }
        public string MediaFile { get; set; }
        public string MediaDescription { get; set; }
        public bool AutoPlayMedia { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }

        public bool AlreadyAutoPlayed { get; set; }



        public WFInfoCategory[] GetAllCategories()
        {
            List<WFInfoCategory> result = new List<WFInfoCategory>();

            result.Add(WFInfoCategory.Description);
            result.Add(WFInfoCategory.Interior);
            result.Add(WFInfoCategory.Offer);
            result.Add(WFInfoCategory.OpeningHours);

            return result.ToArray();

        }

        public WFInfoCategory CategoryFromString(string catName)
        {
            try
            {
                foreach (WFInfoCategory lion in GetAllCategories())
                {
                    if (catName.ToLower() == lion.ToString().ToLower())
                    {
                        return lion;

                    } // Match!

                } // foreach

                return WFInfoCategory.Description;
                
            }
            catch
            {
                return WFInfoCategory.Description;

            }

        }

    }
}
