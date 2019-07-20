using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kwenda;
using Mawingu;
#if __IOS__
using CoreLocation;
#endif

namespace WayfindR.Helpers
{
    public class HeadingHelper
    {
#if __IOS__
        private static CLLocationManager locmgr;
#endif

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
			Unknown = -1,
            StraightAhead = 0,
            SlightlyRight = 45,
            Right = 90,
			HardRight = 135,

            SlightlyLeft = -45,
            Left = -90,
			HardLeft = -135,

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

		public static string NaturalDirectionImageName(NaturalDirection direction, bool largeOne)
		{
			string result = string.Empty;
			switch (direction)
			{
				case NaturalDirection.Unknown:
					result = string.Empty;
					break;

				case NaturalDirection.StraightAhead:
					result = "nav_forward";
					break;

				case NaturalDirection.SlightlyRight:
					result = "nav_right_forward";
					break;

				case NaturalDirection.Right:
					result = "nav_turn_right";
					break;

				case NaturalDirection.HardRight:
					result = "nav_right_back";
					break;

				case NaturalDirection.TurnAround:
					result = "nav_back";
					break;

				case NaturalDirection.HardLeft:
					result = "nav_left_back";
					break;

				case NaturalDirection.Left:
					result = "nav_turn_left";
					break;

				case NaturalDirection.SlightlyLeft:
					result = "nav_left_forward";
					break;

				default:
					throw new Exception(string.Format("Unknown natural direction {0}",
				direction.ToString()
				));

			} // switch direction  }

			if (!string.IsNullOrWhiteSpace(result))
			{
				if (largeOne)
				{
					result += "_xl";

				} // xl

				
			} // result is not empty

			return result;

		}


        public static string NaturalDirectionName(NaturalDirection direction)
        {
            switch (direction)
            {
				case NaturalDirection.Unknown:
					return string.Empty;

                case NaturalDirection.StraightAhead:
					return "Straight ahead".Translate();

                case NaturalDirection.SlightlyRight:
					return "Slightly right".Translate();

                case NaturalDirection.Right:
					return "Right".Translate();

                case NaturalDirection.HardRight:
					return "Hard right".Translate();

                case NaturalDirection.TurnAround:
					return "Turn around".Translate();

                case NaturalDirection.HardLeft:
					return "Hard left".Translate();

                case NaturalDirection.Left:
					return "Left".Translate();

                case NaturalDirection.SlightlyLeft:
					return "Slightly left".Translate();

                default:
                    throw new Exception(string.Format("Unknown natural direction {0}",
                        direction.ToString()
                        ));

            } // switch direction

        }


		public static string NaturalDirectionTurnName(NaturalDirection direction)
		{
			if (direction == NaturalDirection.StraightAhead ||
			    direction == NaturalDirection.TurnAround)
			{
				return NaturalDirectionName(direction);

			}
			else
			{
				return string.Format("Turn {0}".Translate(),
				                     NaturalDirectionName(direction).ToLower()
									);
				
			}

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
            < -180 = +
            -270 + 180 = -90
            

            Incomming 60
            Outgoing 330
            330 - 60 = +270
            > +180 = -
            +270 - 180 = +90
            +360 - 270 = +90

			Incomming 0
			Outgoing 330
			330 - 0 = +330
			> +180 = -
			+330 - 180 = +150
			+360 - 330 = -30


			Incomming 23
			Outgoing 330
			330 - 23 = 307
			> +180 = -
			+307 - 180 = +127
			+360 - 307 = -23


            Incomming 300
            Outgoing 30
            30 - 300 = -270
            180 + -270 = -90


            Incomming 0
            Outgoing 270
            270 - 0 = +270
            180 - 270 = -90

            Incomming 330
            Outgoing 300
            300 - 330 = -30

            Incomming 300
            Outgoing 330
            330 - 300 = +30

            */

            int result = outgoing - incomming;

            // > +180 = -
            if (result > 180)
            {
				result = -360 + result;

            }
            else if (result < -180)
            {
                result += 360;

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
            else if (InNaturalSector(headingDiff, NaturalDirection.HardRight))
            {
                return NaturalDirection.HardRight;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.SlightlyLeft))
            {
                return NaturalDirection.SlightlyLeft;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.Left))
            {
                return NaturalDirection.Left;
            }
            else if (InNaturalSector(headingDiff, NaturalDirection.HardLeft))
            {
                return NaturalDirection.HardLeft;
            }
            else if (InNaturalSector(Math.Abs(headingDiff), NaturalDirection.TurnAround))
            {
                return NaturalDirection.TurnAround;
            }
            

            throw new ArgumentOutOfRangeException(string.Format("Heading out of range ({0})",
                headingDiff
                ));

        } // NaturalTurn


        public static int CurrentHeading(int magneticOffset)
        {
            try
            {
                int result = 0;

#if __IOS__
                if (CLLocationManager.HeadingAvailable)
                {
                    if (locmgr == null)
                    {
                        locmgr = new CLLocationManager();
                        locmgr.StartUpdatingHeading();

                    }

                    result = Convert.ToInt16(
                        Math.Round(locmgr.Heading.MagneticHeading)
                    );

                } // Heading availible
#elif __ANDROID__
#warning Implement this
#endif
                result -= magneticOffset;
                result = ValidHeading(result);
                return result;

            }
            catch (Exception ex)
            {
                LogCenter.Error("CurrentHeading", ex.Message);
                return 0;

            }


        }

        public static int ValidHeading(int heading)
        {
            int result = heading;
			while (result < 0)
            {
                result += 360;

            }
			while (result >= 360)
            {
                result -= 360;

            }

            return result;

        }

    }
}
