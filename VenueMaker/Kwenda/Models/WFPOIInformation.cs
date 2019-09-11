using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class WFPOIInformation : INotifyPropertyChanged
    {
        private string _guid;
        private string _information;
        private WFInfoCategory _category;
        private string _mediafile;
        private string _mediadescr;
        private bool _autoplaymedia;
        private DateTime? _startsat;
        private DateTime? _endsat;
        private string _linkurl;


        public string Guid
        {
            get { return _guid; }
            set
            {
                _guid = value;
                FirePropertyChanged(nameof(Guid));
            } // set
        } // Guid
        public string Information
        {
            get { return _information; }
            set
            {
                _information = value;
                FirePropertyChanged(nameof(Information));
            } // set
        } // Information
        public WFInfoCategory Category
        {
            get { return _category; }
            set
            {
                _category = value;
                FirePropertyChanged(nameof(Category));
            } // set
        } // Category
        public string MediaFile
        {
            get { return _mediafile; }
            set
            {
                _mediafile = value;
                FirePropertyChanged(nameof(MediaFile));
            } // set
        } // MediaFile
        public string MediaDescription
        {
            get { return _mediadescr; }
            set
            {
                _mediadescr = value;
                FirePropertyChanged(nameof(MediaDescription));
            } // set
        } // MediaDescription
        public bool AutoPlayMedia
        {
            get { return _autoplaymedia; }
            set
            {
                _autoplaymedia = value;
                FirePropertyChanged(nameof(AutoPlayMedia));
            } // set
        } // AutoPlayMedia
        public DateTime? StartsAt
        {
            get { return _startsat; }
            set
            {
                _startsat = value;
                FirePropertyChanged(nameof(StartsAt));
            } // set
        } // StartsAt
        public DateTime? EndsAt
        {
            get { return _endsat; }
            set
            {
                _endsat = value;
                FirePropertyChanged(nameof(EndsAt));
            } // set
        } // EndsAt
        public string LinkUrl
        {
            get { return _linkurl; }
            set
            {
                _linkurl = value;
                FirePropertyChanged(nameof(LinkUrl));
            } // set
        } // LinkUrl

        public bool AlreadyAutoPlayed { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void FirePropertyChanged(string propName)
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
