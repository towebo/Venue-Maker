using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WayfindR.Models;
#if __IOS__
using UIKit;
#endif
using Mawingu;

namespace Kwenda
{
    public class NavEngine
    {
        private static NavEngine me;


        public WFGraph Graph { get; set; }
        public WFNode StartingPoint { get; set; }
        public WFNode Destination { get; set; }

        public DirectionsList Directions { get; set; }

        public static NavEngine Me
        {
            get
            {
                if (me == null)
                {
                    me = new NavEngine();
                }
                return me;
            } // get
        } // Me

        public NavEngine()
        {
            Directions = new DirectionsList();

        }

        public void CalculateRoute()
        {
            try
            {
                Directions = new DirectionsList();

                if (StartingPoint != null &&
                    Destination != null &&
                    Graph != null)
                {
                    
                    var dirs = Graph.CalculateRoute(
                        StartingPoint,
                        Destination
                    );




                    Directions.SetDirections(dirs);
                    

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public void CheckForObsticlesOnRoute()
        {
            try
            {
                var dirs = Directions.Route;

                string routeerror = string.Empty;
                if (!RoutePreferences.Me.Elevators &&
                    dirs.Where(w => w.TravelType == WFTravelType.Elevator.ToString().ToLower()).Any())
                {
                    routeerror = "I'm sorry but the route contains at least one elevator.".Translate();

                } // Elevator
                else if (!RoutePreferences.Me.Escalators &&
                    dirs.Where(w => w.TravelType == WFTravelType.Escalator.ToString().ToLower()).Any())
                {
                    routeerror = "I'm sorry but the route contains at least one escalator.".Translate();

                } // Escalator
                else if (!RoutePreferences.Me.Stairs &&
                    dirs.Where(w => w.TravelType == WFTravelType.Stairs.ToString().ToLower()).Any())
                {
                    routeerror = "I'm sorry but the route contains at least one stair.".Translate();

                } // Stairs
                else if (!RoutePreferences.Me.GridStairs &&
                    dirs.Where(w => w.TravelType == WFTravelType.GridStairs.ToString().ToLower()).Any())
                {
                    routeerror = "I'm sorry but the route contains at least one grid stair.".Translate();

                } // Grid Stair
                else if (!RoutePreferences.Me.Ladders &&
                    dirs.Where(w => w.TravelType == WFTravelType.Ladder.ToString().ToLower()).Any())
                {
                    routeerror = "I'm sorry but the route contains at least one ladder.".Translate();

                } // Ladder

                if (!string.IsNullOrWhiteSpace(routeerror))
                {
#if __IOS__
                    UIAlertController alert = UIAlertController.Create(
                        "Found obsticle".Translate(),
                        routeerror,
                        UIAlertControllerStyle.Alert
                        );

                    alert.AddAction(UIAlertAction.Create(
                        "Dismiss".Translate(),
                        UIAlertActionStyle.Default,
                        (obj) => LogCenter.CurrentVC.DismissViewController(true, null)
                        ));

                    LogCenter.CurrentVC.PresentViewController(alert, true, null);
#endif

                } // Contains error

            }
            catch (Exception ex)
            {
                LogCenter.Error("CheckForObsticlesOnRoute", ex.Message);

            }
        }


    }
}
