using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace WayfindR.Helpers
{
    public class FloorComparer : IComparer<WFPointOfInterest>, IComparer<WFNode>, IComparer<string>
    {
        public int Compare(WFPointOfInterest a, WFPointOfInterest b)
        {
            int result = Compare(a.Building, b.Building);
            if (result != 0)
            {
                return result;

            } // Building differs

            int floora_ord = a.FloorOrdinal;
            int floorb_ord = b.FloorOrdinal;

            // Not set so use the string value instead.
            if (0 == floora_ord &&
                0 == floorb_ord)
            {
                string floora = a.Floor;
                string floorb = b.Floor;

                result = Compare(floora, floorb);

            }
            else
            {
                result = floora_ord - floorb_ord;

            } // Compare floors

            if (result == 0)
            {
                result = string.Compare(a.Name, b.Name);

            } // Same floor

            return result;
        }

        public int Compare(WFNode a, WFNode b)
        {
            int result = Compare(a.Building, b.Building);
            if (result != 0)
            {
                return result;

            } // Building differs

            // Not set so use the string value instead
            if (0 == a.FloorOrdinal &&
                 0 == b.FloorOrdinal)
            {
                result = Compare(a.Floor, b.Floor);
            }
            else
            {
                result = a.FloorOrdinal - b.FloorOrdinal;

            } // Compare floors

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
