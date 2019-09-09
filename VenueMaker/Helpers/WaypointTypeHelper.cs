using Kwenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace WayfindR.Helpers
{
    public static class WaypointTypeHelper
    {
        private static Dictionary<string, WFWaypointType> waypointtypesdict;

        public static Dictionary<string, WFWaypointType> ToDictionary()
        {
            Dictionary<string, WFWaypointType> result = new Dictionary<string, WFWaypointType>();

            result.Add(
                WFWaypointType.Undefined.ToString().ToLower(),
                WFWaypointType.Undefined
                );
            result.Add(
                WFWaypointType.Artifact.ToString().ToLower(),
                WFWaypointType.Artifact
                );
            result.Add(
                WFWaypointType.Artwork.ToString().ToLower(),
                WFWaypointType.Artwork
                );
            result.Add(
                WFWaypointType.Bridge.ToString().ToLower(),
                WFWaypointType.Bridge
                );
            result.Add(
                WFWaypointType.BusStop.ToString().ToLower(),
                WFWaypointType.BusStop
                );
            result.Add(
                WFWaypointType.Door.ToString().ToLower(),
                WFWaypointType.Door
                );
            result.Add(
                WFWaypointType.Elevator.ToString().ToLower(),
                WFWaypointType.Elevator
                );
            result.Add(
                WFWaypointType.EmergencyExit.ToString().ToLower(),
                WFWaypointType.EmergencyExit
                );
            result.Add(
                WFWaypointType.Entrance.ToString().ToLower(),
                WFWaypointType.Entrance
                );
            result.Add(
                WFWaypointType.Escalator.ToString().ToLower(),
                WFWaypointType.Escalator
                );
            result.Add(
                WFWaypointType.Exit.ToString().ToLower(),
                WFWaypointType.Exit
                );
            result.Add(
                WFWaypointType.Gate.ToString().ToLower(),
                WFWaypointType.Gate
                );
            result.Add(
                WFWaypointType.HWC.ToString().ToLower(),
                WFWaypointType.HWC
                );
            result.Add(
                WFWaypointType.Object.ToString().ToLower(),
                WFWaypointType.Object
                );
            result.Add(
                WFWaypointType.Platform.ToString().ToLower(),
                WFWaypointType.Platform
                );
            result.Add(
                WFWaypointType.Reception.ToString().ToLower(),
                WFWaypointType.Reception
                );
            result.Add(
                WFWaypointType.Revolvingdoor.ToString().ToLower(),
                WFWaypointType.Revolvingdoor
                );
            result.Add(
                WFWaypointType.Sculpture.ToString().ToLower(),
                WFWaypointType.Sculpture
                );
            result.Add(
                WFWaypointType.Slidingdoors.ToString().ToLower(),
                WFWaypointType.Slidingdoors
                );
            result.Add(
                WFWaypointType.Stairs.ToString().ToLower(),
                WFWaypointType.Stairs
                );
            result.Add(
                WFWaypointType.Stop.ToString().ToLower(),
                WFWaypointType.Stop
                );
            result.Add(
                WFWaypointType.TaxiStop.ToString().ToLower(),
                WFWaypointType.TaxiStop
                );
            result.Add(
                WFWaypointType.Ticketgate.ToString().ToLower(),
                WFWaypointType.Ticketgate
                );
            result.Add(
                WFWaypointType.WC.ToString().ToLower(),
                WFWaypointType.WC
                );

            return result;

        }

        public static WaypointTypeListItem[] ToDisplayList()
        {
            List<WaypointTypeListItem> result = new List<WaypointTypeListItem>();

            result.Add(new WaypointTypeListItem(
                WFWaypointType.Undefined,
                " "
                ));
            /*tmp
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Artifac,
                "Artifact"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Artwork,
                "Konstverk"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Bridge,
                "Bro"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.BusStop,
                "Busshållplats"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Door,
                "Dörr"
                ));
            */
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Elevator,
                "Hiss"
                ));
            /*tmp
            result.Add(new WaypointTypeListItem(
                WFWaypointType.EmergencyExit,
                "Nödutgång"
                ));
                */
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Entrance,
                "Ingång"
                ));
            /*
            result.Add(
                WFWaypointType.Escalator,
                "Rulltrappa"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Exit,
                "Utgång"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Gate,
                "Gate"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.HWC,
                "Handikapp WC"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Object,
                "Objekt"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Platform,
                "Plattform"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Reception,
                "Reception"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Revolvingdoor,
                "Roterande dörr"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Sculpture,
                "Skulptur"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Slidingdoors,
                "Skjutdörrar"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Stairs,
                "Trappa"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Stop,
                "Hållplats"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.TaxiStop,
                "Taxistopp"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.Ticketgate,
                "Biljettgrind"
                ));
            result.Add(new WaypointTypeListItem(
                WFWaypointType.WC,
                "WC"
                ));
            */

            return result.ToArray();

        }


        public static WFWaypointType ToWaypointType(this string str)
        {
            try
            {
                if (waypointtypesdict == null)
                {
                    waypointtypesdict = ToDictionary();

                } // Not initiated

                WFWaypointType result = waypointtypesdict[str.ToLower()];

                return result;

            }
            catch
            {
                return WFWaypointType.Undefined;

            }

        }



    }

    public class WaypointTypeListItem
    {
        public WFWaypointType WaypointType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }


        public WaypointTypeListItem(WFWaypointType  wpType, string dispName)
        {
            WaypointType = wpType;
            Name = WaypointType.ToString().ToLower();
            DisplayName = dispName;

        }


    }


}
