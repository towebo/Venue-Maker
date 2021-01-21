using Kwenda.Models;
using System;
#if __IOS__
using CoreLocation;
using Foundation;
//using GimbalFramework;
#elif __ANDROID__
using UniversalBeacon.Library.Core.Entities;
#endif

namespace WayfindR.Models
{
	public enum RegionMask
	{
		Uuid,
		UuidMajor,
		UuidMajorMinor

	} // enum

	public partial class BLEBeacon
	{
		public BLEBeacon ()
		{
		}


#if __IOS__
        public static double? CalculateDistance(nint txPower, nint rssi)
#elif __ANDROID__
        public static double? CalculateDistance(int txPower, int rssi)
#else
        public static double? CalculateDistance(int txPower, int rssi)
#endif
        {
			double? result = null;

			if (rssi == 0)
			{
				return result;

			} // rssi == 0

			double ratio = rssi * 1.0 / txPower;
			if (ratio < 1.0)
			{
				result = Math.Pow (ratio, 10);
			}
			else {
				double accuracy = (0.89976) * Math.Pow (ratio, 7.7095) + 0.111;
				result = accuracy;
			}

			return result;

		}

#if __IOS__
        public void Update(CLBeacon aBeacon)
        {
			try
			{
                // Out of reach
				if (aBeacon.Rssi >= 0)
				{
					numzerorssis++;

					if (numzerorssis < 8)
					{
						return;

					}

				}

				numzerorssis = 0;

				LastUpdated = DateTime.Now;

                Uuid = aBeacon.ProximityUuid.ToString();
                Major = (int)aBeacon.Major;
				Minor = (int)aBeacon.Minor;
                Accuracy = aBeacon.Accuracy;
                Proximity = aBeacon.Proximity;
				Rssi = (int)aBeacon.Rssi;



                if (OnUpdated != null)
				{
					OnUpdated (this, new EventArgs ());

				}
				
			}
			catch 
			{
				
			}

		} // Update iBeacon
#endif
        /*
		public void Update(GMBLBeaconSighting aSighting)
		{
			try
			{
				LastUpdated = DateTime.Now;
				Id = aSighting.Beacon.Identifier;
				Accuracy = GimbalRSSI.Distance (aSighting.RSSI);
				Proximity = GimbalRSSI.Proximity (aSighting.RSSI);

				if (OnUpdated != null)
				{
					OnUpdated (this, new EventArgs ());

				}

			}
			catch 
			{
				
			}

		} // Update Gimbal beacon
		*/


        public bool InRange()
		{
			return Rssi != 0;
		}

		public bool InRange (double value)
		{
			return value >= 0.0;
		}


		// iBeacon
        public string Uuid { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }

		// Gimbal
		public string Name { get; set; }
		public string Id { get; set; }
		public int Rssi { get; set; }
		public double Accuracy { get; set; }
#if __IOS__
        public CLProximity Proximity { get; set; }
#endif
        public DateTime LastUpdated { get; set; }

		public double Distance
		{
			get
			{
				double? dist = CalculateDistance (-59, this.Rssi);
				return dist.HasValue ? dist.Value : -1.0;
			}
		}

#if __IOS__
		public CLProximity Proximity_Fast
		{
			get
			{
				double dist = Distance;
				if (dist < 0.0)
				{
					return CLProximity.Unknown;
				}
				else if (dist < 0.3)
				{
					return CLProximity.Immediate;
				}
				else if (dist < 4.0)
				{
					return CLProximity.Near;
				}
				else
				{
					return CLProximity.Far;
				}

			}
		}


        public CLRegion GetRegion(RegionMask mask)
        {            
            if (string.IsNullOrEmpty(Uuid))
            {
                return null;

            } // uuid is null

            string regionidentifyer = string.Empty;

			switch (mask)
			{
				case RegionMask.Uuid:
                    regionidentifyer = Uuid;

                    return new CLBeaconRegion(
						new NSUuid(Uuid),
						regionidentifyer
						);

				case RegionMask.UuidMajor:
                    regionidentifyer = string.Format("{0}|{1}",
                        Uuid,
                        Major
                        );
					return new CLBeaconRegion(
						new NSUuid(Uuid),
						(ushort)Major,
						regionidentifyer
						);

				case RegionMask.UuidMajorMinor:
                    regionidentifyer = string.Format("{0}|{1}|{2}",
                        Uuid,
                        Major,
                        Minor
                        );
					return new CLBeaconRegion(
					new NSUuid(Uuid),
					(ushort)Major,
					(ushort)Minor,
					regionidentifyer
					);

				default:
					return null;
			} // switch

        }
#endif


        public event EventHandler<EventArgs> OnUpdated;

    }




}

