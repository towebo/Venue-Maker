using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace VenueMaker.Models
{
    public class InfoCategoryItem : INotifyPropertyChanged
    {
        private WFInfoCategory _cat;
        private string _name;
        private string _displname;

        public WFInfoCategory Category
        {
            get { return _cat; }
            set
            {
                _cat = value;
                FirepropertyChanged(nameof(Category));
            }
        } // Category
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                FirepropertyChanged(nameof(Name));
            } // set
        } // Name} // Name
        public string DisplayName
        {
            get { return _displname; }
            set
            {
                _displname = value;
                FirepropertyChanged(nameof(DisplayName));
            } // set
        } // DisplayName

        public event PropertyChangedEventHandler PropertyChanged;

        public InfoCategoryItem(WFInfoCategory cat, string name, string dispName)
        {
            this.Category = cat;
            this.Name = name;
            this.DisplayName = dispName;
                        
        }

        public static InfoCategoryItem[] GetAll()
        {
            List<InfoCategoryItem> result = new List<InfoCategoryItem>();

            foreach (WFInfoCategory cat in Enum.GetValues(typeof(WFInfoCategory)))
            {
                result.Add(new InfoCategoryItem(
                cat, cat.ToString().ToLower(), cat.ToString()
                ));

            } // foreach
            
            return result.ToArray();

        }

        public static InfoCategoryItem[] ToDisplayList()
        {
            List<InfoCategoryItem> result = new List<InfoCategoryItem>();

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Uncategorized,
                WFInfoCategory.Uncategorized.ToString().ToLower(),
                "(saknar kategori)"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Description,
                WFInfoCategory.Description.ToString().ToLower(),
                "Beskrivning"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Interior,
                WFInfoCategory.Interior.ToString().ToLower(),
                "Inredningsbeskrivning"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.OpeningHours,
                WFInfoCategory.OpeningHours.ToString().ToLower(),
                "Öppettider"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Offer,
                WFInfoCategory.Offer.ToString().ToLower(),
                "Erbjudande"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.DescriptiveImage,
                WFInfoCategory.DescriptiveImage.ToString().ToLower(),
                "Beskrivande bild/pktogram"
                ));

            /*tmp
            result.Add(new InfoCategoryItem(
                WFInfoCategory.Review,
                WFInfoCategory.Review.ToString().ToLower(),
                "Recension"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Tips,
                WFInfoCategory.Tips.ToString().ToLower(),
                "Tips"
                ));

            result.Add(new InfoCategoryItem(
                WFInfoCategory.Community,
                WFInfoCategory.Community.ToString().ToLower(),
                "Community"
                ));
            */

            return result.ToArray();

        }

        private void FirepropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(
                        propName
                        )
                        );
            } // Event is hooked up
        }


    }
}
