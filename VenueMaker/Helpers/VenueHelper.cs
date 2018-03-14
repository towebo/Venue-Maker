using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace VenueMaker.Helpers
{
    public static class VenueHelper
    {

        public static string GetFileTitle(this WFVenue venue)
        {
            if (venue == null)
            {
                return string.Empty;

            } //

            string result = string.Format("{0}, {1} ({2})",
                venue.Name,
                venue.City,
                venue.Id
                );

            return result;

        }


    }
}
