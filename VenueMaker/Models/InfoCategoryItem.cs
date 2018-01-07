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

            foreach (WFInfoCategory cat in Enum.GetValues(typeof(WFInfoCategory)))
            {
                result.Add(new InfoCategoryItem(
                cat, cat.ToString().ToLower()
                ));

            } // foreach
            
            return result.ToArray();

        }

    }
}
