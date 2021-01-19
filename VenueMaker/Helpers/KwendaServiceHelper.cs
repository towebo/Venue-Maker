using KWENDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Helpers
{
    public static class KwendaServiceHelper
    {


        public static string TitleForList(this KWENDAFileItem item)
        {
            if (item == null)
            {
                return string.Empty;

            }

            if (!string.IsNullOrWhiteSpace(item.FileTitle))
            {
                return item.FileTitle;

            }
            else
            {
                return item.FileName;

            }

        }

        


    }
}
