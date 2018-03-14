using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenueMaker.Kwenda;

namespace VenueMaker.Helpers
{
    public static class KwendaServiceHelper
    {


        public static string TitleForList(this KwendaFileItem item)
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
