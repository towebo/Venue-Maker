﻿using System;
//using CoreLocation;
//using GimbalFramework;

namespace WayfindR.Models
{
	public class BLEBeacon
	{
		private int numzerorssis;


		public BLEBeacon ()
		{
		}


        //public static double CalculateDistance(nint txPower, nint rssi)
        public static double CalculateDistance(int txPower, int rssi)
        {
			double result = -1.0;

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



        /* tmp
		public void Update(CLBeacon aBeacon)
		{
			try
			{
				if (aBeacon.Rssi >= 0)
				{
					numzerorssis++;
					//AudioToolbox.SystemSound.Vibrate.PlaySystemSound ();

					if (numzerorssis < 8)
					{
						return;

					}

				}

				numzerorssis = 0;

				LastUpdated = DateTime.Now;
				Major = (int)aBeacon.Major;
				Minor = (int)aBeacon.Minor;
				Accuracy = aBeacon.Accuracy;
				Proximity = aBeacon.Proximity;
				Rssi = aBeacon.Rssi;


				if (OnUpdated != null)
				{
					OnUpdated (this, new EventArgs ());

				}
				
			}
			catch 
			{
				
			}

		} // Update iBeacon

        tmp */

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
		public int Major { get; set; }
		public int Minor { get; set; }

		// Gimbal
		public string Name { get; set; }
		public string Id { get; set; }
        //tmp public nint Rssi { get; set; }
        public int Rssi { get; set; }
        public double Accuracy { get; set; }
		//tmp public CLProximity Proximity { get; set; }
		public DateTime LastUpdated { get; set; }

		public double Distance
		{
			get
			{
				return CalculateDistance (-59, this.Rssi);
			}
		}

        /* tmp
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

        tmp */

		public event EventHandler<EventArgs> OnUpdated;

	}




}

