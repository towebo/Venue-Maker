using System;
using System.Collections.Generic;
using System.Text;
using WayfindR.Models;

namespace WayfindR.Helpers
{
    public static class TravelTypeHelper
    {
        private static Dictionary<string, WFTravelType> traveltypedict;

        public static Dictionary<string, WFTravelType> ToDictionary()
        {
            Dictionary<string, WFTravelType> result = new Dictionary<string, WFTravelType>();

            result.Add(
                WFTravelType.Undefined.ToString().ToLower(),
                WFTravelType.Undefined
                );
            result.Add(
                WFTravelType.Elevator.ToString().ToLower(),
                WFTravelType.Elevator
                );
            result.Add(
                WFTravelType.Escalator.ToString().ToLower(),
                WFTravelType.Escalator
                );
            result.Add(
                WFTravelType.Stairs.ToString().ToLower(),
                WFTravelType.Stairs
                );
            result.Add(
                WFTravelType.GridStairs.ToString().ToLower(),
                WFTravelType.GridStairs
                );
            result.Add(
                WFTravelType.Ladder.ToString().ToLower(),
                WFTravelType.Ladder
                );

            return result;

        }

        public static WFTravelType ToTravelType(this string str)
        {
            try
            {
                if (traveltypedict == null)
                {
                    traveltypedict = ToDictionary();

                } // Not initiated

                WFTravelType result = traveltypedict[str.ToLower()];

                return result;

            }
            catch
            {
                return WFTravelType.Undefined;

            }

        }



    }
}
