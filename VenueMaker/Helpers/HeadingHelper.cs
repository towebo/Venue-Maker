//using CoreLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Helpers
{
    public class HeadingHelper
    {
        //private static CLLocationManager locmgr;

        public enum ClockwizeDirection
        {
            TwelveOClock = 0,
            OneOClock = 30,
            TwoOClock = 60,
            ThreeOClock = 90,
            FourOClock = 120,
            FiveOClock = 150,

            ElevenOClock = -30,
            TenOClock = -60,
            NineOClock = -90,
            EightOClock = -120,
            SevenOClock = -150,

            SixOClock = 180

        } // ClockwiseDirection

        public enum NaturalDirection
        {
            StraightAhead = 0,
            SlightlyRight = 45,
            Right = 90,
            SharpRight = 135,

            SlightlyLeft = -45,
            Left = -90,
            SharpLeft = -135,

            TurnAround = 180
        } // NaturalDirection

        public static string ClockwizeDirectionName(ClockwizeDirection direction)
        {
            switch (direction)
            {
                case ClockwizeDirection.OneOClock:
                    return "Klockan 1";

                case ClockwizeDirection.TwoOClock:
                    return "Klockan 2";

                case ClockwizeDirection.ThreeOClock:
                    return "Klockan 3";

                case ClockwizeDirection.FourOClock:
                    return "Klockan 4";

                case ClockwizeDirection.FiveOClock:
                    return "Klockan 5";

                case ClockwizeDirection.SixOClock:
                    return "Klockan 6";

                case ClockwizeDirection.SevenOClock:
                    return "Klockan 7";

                case ClockwizeDirection.EightOClock:
                    return "Klockan 8";

                case ClockwizeDirection.NineOClock:
                    return "Klockan 9";

                case ClockwizeDirection.TenOClock:
                    return "Klockan 11";

                case ClockwizeDirection.ElevenOClock:
                    return "Klockan 11";

                case ClockwizeDirection.TwelveOClock:
                    return "Klockan 12";

                default:
                    throw new ArgumentException(string.Format("Unknown clockwize direction: {0}",
                        direction.ToString()
                        ));
                    

            } // switch direction

        }

        public static string NaturalDirectionName(NaturalDirection direction)
        {
            switch (direction)
            {
                case NaturalDirection.StraightAhead:
                    return "Rakt fram";

                case NaturalDirection.SlightlyRight:
                    return "Svagt åt höger";

                case NaturalDirection.Right:
                    return "Höger";

                case NaturalDirection.SharpRight:
                    return "Skarpt åt höger";

                case NaturalDirection.TurnAround:
                    return "Vänd om";

                case NaturalDirection.SharpLeft:
                    return "Skarpt åt vänster";

                case NaturalDirection.Left:
                    return "Vänster";

                case NaturalDirection.SlightlyLeft:
                    return "Svagt åt vänster";

                default:
                    throw new Exception(string.Format("Unknown natural direction {0}",
                        direction.ToString()
                        ));

            } // switch direction

        }

        public const int ClockwizeSector = 15;
        public const int NaturalSector = 23;

        public static int TurnHeading(int incomming, int outgoing)
        {
            /*
            Incomming = 90
            Outgoing = 180
            180 - 90 = +90

            Incomming 270
            outgoing 180
            180 - 270 = -90

            Incomming 330
            Outgoing 60
            60 - 330 = -270
            -270 + 180 = +90

            Incomming 60
            Outgoing 330
            330 - 60 = +270
            180 - 270 = -90

            Incomming 0
            Outgoing 270
            270 - 0 = +270
            180 - 270 = -90

            Incomming 330
            Outgoing 300
            300 - 330 = -30

            Incomming 300
            Outgoing 330
            330 - 300 = + +30

            */

            int result = outgoing - incomming;

            if (result < -180)
            {
                result += 180;

            }
            else if (result > 180)
            {
                result = 180 - result;

            }

            return result;


        } // TurnHeading      
        
        public static bool InClockwizeSector(int value, ClockwizeDirection direction)
        {
            return value >= ((int)direction - ClockwizeSector) &&
                value <= ((int)direction + ClockwizeSector);

        }

        public static ClockwizeDirection ClockwizeTurn(int headingDiff)
        {
            if (InClockwizeSector(headingDiff, ClockwizeDirection.TwelveOClock))
            {
                return ClockwizeDirection.TwelveOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.OneOClock))
            {
                return ClockwizeDirection.OneOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.TwoOClock))
            {
                return ClockwizeDirection.TwoOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.ThreeOClock))
            {
                return ClockwizeDirection.ThreeOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.FourOClock))
            {
                return ClockwizeDirection.FourOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.FiveOClock))
            {
                return ClockwizeDirection.FiveOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.SixOClock))
            {
                return ClockwizeDirection.SixOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.SevenOClock))
            {
                return ClockwizeDirection.SevenOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.EightOClock))
            {
                return ClockwizeDirection.EightOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.NineOClock))
            {
                return ClockwizeDirection.NineOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.TenOClock))
            {
                return ClockwizeDirection.TenOClock;
            }
            else if (InClockwizeSector(headingDiff, ClockwizeDirection.ElevenOClock))
            {
                return ClockwizeDirection.ElevenOClock;
            }

            throw new ArgumentOutOfRangeException(string.Format("Heading out of bounds ({0})",
                headingDiff
                ));

        } // ClockwizeTurn

        public static bool InNaturalSector(int value, NaturalDirection direction)
        {
            return value >= ((int)direction - NaturalSector) &&
                value <= ((int)direction + NaturalSector);

        }

        public static NaturalDirection NaturalTurn(int headingDiff)
        {
            if (InNaturalSector(headingDiff, NaturalDirection.StraightAhead))
            {
                return NaturalDirection.StraightAhead;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.SlightlyRight))
            {
                return NaturalDirection.SlightlyRight;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.Right))
            {
                return NaturalDirection.Right;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.SharpRight))
            {
                return NaturalDirection.SharpRight;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.SlightlyLeft))
            {
                return NaturalDirection.SlightlyLeft;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.Left))
            {
                return NaturalDirection.Left;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.SharpLeft))
            {
                return NaturalDirection.SharpLeft;
            }
            else if (InNaturalSector(Math.Abs(headingDiff), NaturalDirection.TurnAround))
            {
                return NaturalDirection.TurnAround;
            }
            

            throw new ArgumentOutOfRangeException(string.Format("Heading out of range ({0})",
                headingDiff
                ));

        } // NaturalTurn
        
        public static int CurrentHeading()
        {
            /*
            if (CLLocationManager.HeadingAvailable)
            {
                if (locmgr == null)
                {
                    locmgr = new CLLocationManager();
                    locmgr.StartUpdatingHeading();

                }

                return Convert.ToInt16(
                    Math.Round(locmgr.Heading.MagneticHeading)
                );

            }
            */

            return 0;




        }

        public static int ValidHeading(int heading)
        {
            int result = heading;
            if (result < 0)
            {
                result += 360;

            }
            else if (result >= 360)
            {
                result -= 360;

            }

            return result;

        }

    }
}
