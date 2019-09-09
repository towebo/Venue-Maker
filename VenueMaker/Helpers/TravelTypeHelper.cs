using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            result.Add(
                WFTravelType.RevolvingDoor.ToString().ToLower(),
                WFTravelType.RevolvingDoor
                );
            result.Add(
                WFTravelType.Ramp.ToString().ToLower(),
                WFTravelType.Ramp
                );

            return result;

        }

        public static TravelTypeListItem[] ToDisplayList()
        {
            List<TravelTypeListItem> result = new List<TravelTypeListItem>();

            result.Add(new TravelTypeListItem(
                WFTravelType.Undefined,
                " "
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.Elevator,
                "Hiss"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.Escalator,
                "Rulltrappa"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.Stairs,
                "Trappa"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.GridStairs,
                "Galletrappa"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.Ladder,
                "Stege"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.RevolvingDoor,
                "Roterande dörr"
                ));
            result.Add(new TravelTypeListItem(
                WFTravelType.Ramp,
                "Ramp"
                ));

            return result.ToArray();

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



    } // class

    public class TravelTypeListItem : INotifyPropertyChanged
    {
        public WFTravelType TravelType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TravelTypeListItem(WFTravelType travelType, string dispName)
        {
            TravelType = travelType;
            Name = TravelType.ToString().ToLower();
            DisplayName = dispName;

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