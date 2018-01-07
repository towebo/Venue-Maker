using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace VenueMaker.Models
{
    public class InfoCategoryItem
    {
        public WFInfoCategory Category { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }


        public InfoCategoryItem(WFInfoCategory cat, string name)
        {
            this.Category = cat;
            this.Name = name;
                        

        }

        public static InfoCategoryItem[] GetAll()
        {
            List<InfoCategoryItem> result = new List<InfoCategoryItem>();

            result.Add(new InfoCategoryItem(
                WFInfoCategory.General, WFInfoCategory.General.ToString().ToLower()
                ));
            result.Add(new InfoCategoryItem(
                WFInfoCategory.AudioDescription, WFInfoCategory.AudioDescription.ToString().ToLower()
                ));
            result.Add(new InfoCategoryItem(
                WFInfoCategory.Interior, WFInfoCategory.Interior.ToString().ToLower()
                ));
            result.Add(new InfoCategoryItem(
                WFInfoCategory.Offer, WFInfoCategory.Offer.ToString().ToLower()
                ));
            result.Add(new InfoCategoryItem(
                WFInfoCategory.OpeningHours, WFInfoCategory.OpeningHours.ToString().ToLower()
                ));
            

            return result.ToArray();

        }

    }
}
