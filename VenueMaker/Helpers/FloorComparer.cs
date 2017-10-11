using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace Radar
{
    public class FloorComparer : IComparer<WFPointOfInterest>, IComparer<WFNode>, IComparer<string>
    {
        public int Compare(WFPointOfInterest a, WFPointOfInterest b)
        {
            string floora = a.Floor;
            string floorb = b.Floor;

            int result = Compare(floora, floorb);

            if (result == 0)
            {
                result = string.Compare(a.Name, b.Name);

            } // Same floor

            return result;
        }

        public int Compare(WFNode a, WFNode b)
        {
            int result = Compare(a.Floor, b.Floor);
            if (result == 0)
            {
                result = string.Compare(a.Name, b.Name);


            } // Same floor

            return result;

        }

        public int Compare(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) &&
                string.IsNullOrWhiteSpace(b))
            {
                return 0;

            } // Both are blank

            if (a.IsNumeric() &&
                b.IsNumeric())
            {
                return Convert.ToInt32(a) - Convert.ToInt32(b);

            } // Both are numeric

            if (string.IsNullOrWhiteSpace(a) ||
                string.IsNullOrWhiteSpace(b))
            {
                return string.IsNullOrWhiteSpace(a) ? -1 : 1;

            } // One string is blank

            int anum = 0;
            int bnum = 0;

            if (a.IsNumeric())
            {
                anum = Convert.ToInt32(a);

            }
            else
            {
                if ("E" == a.Trim().ToUpper() ||
                    "BV" == a.Trim().ToUpper())
                {
                    anum = 0;

                }
                else if ("K" == a.Trim().ToUpper())
                {
                    anum = Int32.MaxValue;

                }

            } // Not numeric
            

            if (b.IsNumeric())
            {
                bnum = Convert.ToInt32(b);

            }
            else
            {
                if ("E" == b.Trim().ToUpper() ||
                    "BV" == b.Trim().ToUpper())
                {
                    bnum = 0;

                }
                else if ("K" == b.Trim().ToUpper())
                {
                    bnum = Int32.MaxValue;

                }

            } // Not numeric

            return anum - bnum;
            
        }


    }

}
