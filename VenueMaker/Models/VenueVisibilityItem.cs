using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WayfindR.Models
{
    public class VenueVisibilityItem
    {

        public VenueVisibillity Visibility { get; set; }
        public string Title { get; set; }


        public static VenueVisibilityItem[] GetPossibleVisibilities()
        {
            List<VenueVisibilityItem> result = new List<VenueVisibilityItem>();
            result.Add(new VenueVisibilityItem()
            {
                Visibility = VenueVisibillity.Never,
                Title = "Aldrig"
            });
            result.Add(new VenueVisibilityItem()
            {
                Visibility = VenueVisibillity.Always,
                Title = "Alltid"
            });
            result.Add(new VenueVisibilityItem()
            {
                Visibility = VenueVisibillity.WhenNodeInRange,
                Title = "När fyrar är inom räckhåll"
            });

            return result.ToArray();

        }

    }
}
