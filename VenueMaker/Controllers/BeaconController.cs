using System;
using System.Collections.Generic;
//using CoreLocation;
using WayfindR.Models;
//using GimbalFramework;
using System.Linq;

namespace WayfindR.Controllers
{
	public class BeaconController
	{
		private static BeaconController me;

		private List<BLEBeacon> beacons;

		public BeaconController ()
		{
			beacons = new List<BLEBeacon> ();

		}



        public CacheNodeBeacon[] FindNodeBeacon(BLEBeacon bcn)
        {
            try
            {
                var result = (
                    from x in SQLiteController.Me.Db.Table<CacheNodeBeacon>()
                    where x.Major == bcn.Major && x.Minor == bcn.Minor
                    orderby x.GraphLevel descending
                    select x
                    );

                return result.ToArray();

            }
            catch (Exception ex)
            {
                throw;

            }
            
        }

        /* tmp
		public void UpdateBeacon(CLBeacon aBeacon)
		{
			try
			{
				BLEBeacon bb = null;

				foreach (BLEBeacon b in beacons)
				{
					if (b.Major == (int)aBeacon.Major &&
					   b.Minor == (int)aBeacon.Minor)
					{
						bb = b;
						break;
						
					}
					
				} // foreach

				if (bb == null)
				{
					if (aBeacon.Rssi == 0)
					{
						return;
						
					}

					bb = new BLEBeacon ();
					bb.OnUpdated += BeaconWasUpdated;
					beacons.Add (bb);
					bb.Update (aBeacon);

					if (OnBeaconAdded != null)
					{
						OnBeaconAdded (this, bb);
					}

				} // if bb == null
				else
				{
					if (bb.Rssi == 0 &&
				   aBeacon.Rssi == 0) {
						if (OnBeaconRemoved != null) {
							OnBeaconRemoved (this, bb);
						}
						beacons.Remove (bb);
						return;

					}

					bb.Update (aBeacon);

				}

			}
			catch
			{
				
			}
		} // Update iBeacon

        tmp */
		/* Gimbal
		public void UpdateBeacon (GMBLBeaconSighting aSighting)
		{
			try {
				BLEBeacon bb = null;

				foreach (BLEBeacon b in beacons)
				{
					if (aSighting.Beacon.Identifier == b.Id)
					{
						bb = b;
						break;

					}

				} // foreach

				if (bb == null) {
					bb = new BLEBeacon ();
					bb.OnUpdated += BeaconWasUpdated;

				} // if bb == null

				bb.Update (aSighting);


			}
			catch
			{

			}

		} // Update Gimbal beacon
		*/

		protected void BeaconWasUpdated(object sender, EventArgs e)
		{
			try
			{
				if (OnBeaconUpdated != null)
				{
					OnBeaconUpdated (this, (BLEBeacon)sender);

				}
				
			}
			catch
			{
				
			}

		} // BeaconWasUpdated

        
		public static BeaconController Me
		{
			get
			{
				if (me == null)
				{
					me = new BeaconController ();

				}

				return me;

			} // get

		} // Me

		public BLEBeacon[] Beacons
		{
			get
			{
				return beacons.ToArray ();

			} // get

		} // Beacons

        

		public event EventHandler<BLEBeacon> OnBeaconAdded;
		public event EventHandler<BLEBeacon> OnBeaconRemoved;
		public event EventHandler<BLEBeacon> OnBeaconUpdated;




	}
}

