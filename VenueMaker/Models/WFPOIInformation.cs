using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public enum WFInfoCategory
    {
        General,
        AudioDescription,
        PositionIdentifyer,
        OpeningHours,
        Offer,
        PhoneNumber,
        Address,
        Url,
        EmailAddress
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



        
        public WFInfoCategory CategoryFromString(string catName)
        {
            try
            {
                foreach (WFInfoCategory lion in Enum.GetValues(typeof(WFInfoCategory)))
                {
                    if (catName.ToLower() == lion.ToString().ToLower())
                    {
                        return lion;

                    } // Match!

                } // foreach

                return WFInfoCategory.General;
                
            }
            catch
            {
                return WFInfoCategory.General;

            }

        }

    }
}
