using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public enum WFInfoCategory
    {
        Uncategorized,
        Description,
        Interior,
        OpeningHours,
        Offer,
        DescriptiveImage,
        Review,
        Tips,
        Community
    } // enum

    public class WFPOIInformation
    {
        public string Guid { get; set; }
        public string Information { get; set; }
        public WFInfoCategory Category { get; set; }
        public string MediaFile { get; set; }
        public string MediaDescription { get; set; }
        public bool AutoPlayMedia { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public string LinkUrl { get; set; }

        public bool AlreadyAutoPlayed { get; set; }

        public WFPOIInformation()
        {
            Guid = System.Guid.NewGuid().ToString();

        }

        public WFInfoCategory[] GetAllCategories()
        {
            List<WFInfoCategory> result = new List<WFInfoCategory>();

            result.Add(WFInfoCategory.Uncategorized);
            result.Add(WFInfoCategory.Description);
            result.Add(WFInfoCategory.Interior);
            result.Add(WFInfoCategory.Offer);
            result.Add(WFInfoCategory.OpeningHours);
            result.Add(WFInfoCategory.DescriptiveImage);
            result.Add(WFInfoCategory.Review);
            result.Add(WFInfoCategory.Tips);
            result.Add(WFInfoCategory.Community);

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

                return WFInfoCategory.Uncategorized;
                
            }
            catch
            {
                return WFInfoCategory.Uncategorized;

            }

        }

    }
}
