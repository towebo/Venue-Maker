using System;
using System.Collections.Generic;
#if __IOS__
using CoreLocation;
#elif __ANDROID__
using Android.Content;
using UniversalBeacon.Library;
using UniversalBeacon.Library.Core.Entities;
using UniversalBeacon.Library.Core.Interfaces;
#endif
using WayfindR.Models;
//using GimbalFramework;
using System.Linq;
using Kwenda;
using SQLite;
using Kwenda.Models;
using Mawingu;

#if __IOS__
using Foundation;
using CoreBluetooth;
using CoreFoundation;
#endif


namespace WayfindR.Controllers
{
    public class BeaconController
    {
        private static BeaconController me;
#if __IOS__
        private CLLocationManager locman;
#elif __ANDROID__
        private readonly BeaconManager _manager;
#endif

        private List<string> uuids;
        private List<BLEBeacon> beacons;
        private bool? btison;

        private BLEBeacon currently_at;
        private DateTime? left_at;

        private const int StickySeconds = 8;



        public BeaconController()
        {
#if __IOS__
            locman = new CLLocationManager();
            locman.DidRangeBeacons += BeaconsWasRanged;
#elif __ANDROID__
            var provider = new AndroidBluetoothPacketProvider(Ctx);
            if (null != provider)
            {
                // create a beacon manager, giving it an invoker to marshal collection changes to the UI thread
#warning _manager = new BeaconManager(provider, Device.BeginInvokeOnMainThread);
                _manager = new BeaconManager(provider, null);
                _manager.Start();
                _manager.BeaconAdded += _manager_BeaconAdded;
                _manager.BluetoothBeacons.CollectionChanged += BluetoothBeacons_CollectionChanged;
            }
#endif


            beacons = new List<BLEBeacon>();
            uuids = new List<string>();

            /*
            uuids.Add(
                "E2C56DB5-DFFB-48D2-B060-D0F5A71096E0"
                );
			
			uuids.Add (
			"f7826da6-4fa2-4e98-8024-bc5b71e0893e"
			);
            */


        }

#if __ANDROID__
        private void BluetoothBeacons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
#warning Implement this
        }

        private void _manager_BeaconAdded(object sender, Beacon e)
        {
#warning Implement this
        }
#endif

        public void AddUuid(string uuid)
        {
            if (uuids.IndexOf(uuid) == -1)
            {
                uuids.Add(uuid);

            } // Not already present

        }

        public void AddUuids(string[] newUuids)
        {
            foreach (string uuid in newUuids)
            {
                AddUuid(uuid);

            } // foreach

        }

        public void AddDemoBeacon()
        {
            BLEBeacon b = new BLEBeacon();
            b.Major = 100;
            b.Minor = 1;
            beacons.Add(b);
            b.Nodes = FindNodeBeacon(b);
            b.DistanceState = NodeDistanceState.At;
            MakeOthersAwareAboutCurrentlyAt(b);

        }

        public bool AnyOfTheseInRange(WFNode[] nodesToCheck)
        {
            bool result = false;
            foreach (WFNode n in nodesToCheck)
            {
                BLEBeacon b = GetBeaconFromNode(n, false);
                result |= b != null;

            } // foreach

            return result;

        }

        public BLEBeacon GetBeaconFromNode(WFNode node, bool createIfNotFound = true)
        {
            BLEBeacon result = FindBeacon(
                node.Uuid ?? string.Empty,
                node.Major,
                node.Minor
            );

            if (result != null ||
                !createIfNotFound)
            {
                return result;

            } // was found

            result = new BLEBeacon();
            result.Uuid = node.Uuid;
            result.Major = node.Major;
            result.Minor = node.Minor;
            result.Nodes = FindNodeBeacon(result);
            result.DistanceState = NodeDistanceState.OutOfRange;

            return result;

        }

        public void Clear()
        {
            Clear(false);

        }

        public void Clear(bool keepCurrentlyAt)
        {
            beacons.Clear();
            if (keepCurrentlyAt)
            {
                currently_at = null;
                MakeOthersAwareAboutCurrentlyAt(currently_at);

            } // Keep Currently At

        }

        public void ClearUnreachableBeacons()
        {
            try
            {
                var inrangeones = beacons.Where(w => w.InRange());
                beacons = inrangeones.ToList();

            }
            catch (Exception ex)
            {
                LogCenter.Error("ClearUnreacableBeacons()", ex.Message);

            }
        }

        public static CacheNodeBeacon FindNodeBeacon(string uuid, int major, int minor)
        {
            try
            {
                CacheNodeBeacon[] result = (
                        from x in SQLiteController.Me.Db.Table<CacheNodeBeacon>()
                        where x.Uuid.ToLower() == uuid.ToLower() &&
                            x.Major == major &&
                            x.Minor == minor
                        orderby x.GraphLevel descending, x.Uuid descending
                        select x
                    ).ToArray();

                return result.FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }

        public CacheNodeBeacon[] FindNodeBeacon(BLEBeacon bcn)
        {
            try
            {
                CacheNodeBeacon[] result = (
                    from x in SQLiteController.Me.Db.Table<CacheNodeBeacon>()
                    where
                        x.Uuid.ToLower() == bcn.Uuid.ToLower() &&
                        x.Major == bcn.Major &&
                        x.Minor == bcn.Minor
                    orderby x.GraphLevel descending, x.Uuid descending
                    select x
                ).ToArray();


                foreach (CacheNodeBeacon cnb in result)
                {
                    cnb.Graph = GraphController.Me.FindGraph(cnb.GraphId);
                    if (cnb.Graph != null)
                    {
                        cnb.Node = cnb.Graph.Vertices.Where(w =>
                                                         (string.IsNullOrEmpty(w.Uuid) ||
                                                         w.Uuid.ToLower() == bcn.Uuid.ToLower()) &&
                                                         w.Major == bcn.Major &&
                                                         w.Minor == bcn.Minor
                                                          ).FirstOrDefault();


                    } // Graph found


                    cnb.Venue = VenueController.Me.FindVenue(cnb.VenueId);

                } // foreach


                return result.ToArray();

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "FindNodeBeacon()",
                    ex.Message
                    );

                return null;

            }

        }

        public BLEBeacon FindBeacon(string uuid, int major, int minor)
        {
            BLEBeacon result = (
                from x in beacons
                where
                    x.Uuid.ToLower() == uuid.ToLower() &&
                    x.Major == major &&
                    x.Minor == minor
                select x
            ).FirstOrDefault();

            return result;

        }

#if __IOS__
        public void UpdateBeacon(CLBeacon aBeacon)
        {
            try
            {
                BLEBeacon bb = FindBeacon(
                    aBeacon.ProximityUuid.ToString(),
                    (int)aBeacon.Major,
                    (int)aBeacon.Minor
                );

                if (bb == null)
                {
                    if (aBeacon.Rssi == 0 ||
                        aBeacon.Rssi == -1)
                    {
                        return;

                    }


                    bb = new BLEBeacon(aBeacon);
                    bb.Nodes = FindNodeBeacon(bb);
                    bb.OnUpdated += BeaconWasUpdated;
                    bb.OnDistanceStateChanged += BeaconDistanceStateChanged;
                    bb.OnAnnouncement += BeaconMadeAnnouncement;

                    beacons.Add(bb);
                    bb.Update(aBeacon);

                    if (OnBeaconAdded != null)
                    {
                        OnBeaconAdded(this, bb);
                    }

                } // if bb == null
                else
                {
                    if (bb.Rssi == 0 &&
                   aBeacon.Rssi == 0)
                    {
                        beacons.Remove(bb);

                        if (OnBeaconRemoved != null)
                        {
                            OnBeaconRemoved(this, bb);

                        }

                        return;

                    }

                    bb.Update(aBeacon);

                }

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "UpdateBeacon()",
                    ex.Message
                    );

            }
        } // Update iBeacon

#endif

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
			catch (Exception ex)
			{
            LogCenter.Error(
              "UpdateBeacon()",
              ex.Message
              );

			}

		} // Update Gimbal beacon
		*/


        private void MakeOthersAwareAboutCurrentlyAt(BLEBeacon newBeacon)
        {
            if (BeaconAtHasChanged != null)
            {
                BeaconAtHasChanged(this, newBeacon);

            }
        }

        public bool StartRangingBeacons()
        {
            try
            {
                foreach (string uuidstr in Uuids)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(uuidstr))
                        {
                            continue;

                        } // Empty uuid

#if __IOS__
                        NSUuid uuid = new NSUuid(uuidstr);
                        CLBeaconRegion region = new CLBeaconRegion(uuid, uuid.AsString());
                        locman.StartRangingBeacons(region);
#endif
#if __ANDROID__
#endif

                    }
                    catch (Exception uuidex)
                    {
                        string msg = string.Format("{0}, {1}",
                                                   uuidex.Message,
                                                   uuidstr
                                                  );
                        Console.WriteLine(msg);
                        //throw new Exception(msg);
                    }

                } // foreach uuid

#if __IOS__
                var bluetoothManager = new CBCentralManager(
                    new CbCentralDelegate(), DispatchQueue.DefaultGlobalQueue,
                    new CBCentralInitOptions { ShowPowerAlert = true }
                );

                var btstate = bluetoothManager.State;

                if (btstate != CBCentralManagerState.Unknown)
                {
                    btison = btstate == CBCentralManagerState.PoweredOn;
                    
                }
#elif __ANDROID__
#warning Implement this
#endif

                return !btison.HasValue ||
                              (btison.HasValue && btison.Value);

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconController.StartRangingBeacons()",
                    ex.Message
                    );
                return false;
            }
        }

        public void StopRangingBeacons()
        {
            StopRangingBeacons(Uuids);

        }

        public void StopRangingBeacons(string[] aUuids)
        {
            try
            {
                foreach (string uuidstr in aUuids)
                {
                    try
                    {
#if __IOS__
                        NSUuid uuid = new NSUuid(uuidstr);
                        CLBeaconRegion rgn = new CLBeaconRegion(uuid, uuid.AsString());
                        locman.StopRangingBeacons(rgn);
#endif
#if __ANDROID__
#endif

                    }
                    catch (Exception ex)
                    {
                        LogCenter.Error("StopRangingBeacons()", ex.Message);
                    }

                } // foreach uuid

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconController.StopRangingBeacons()",
                    ex.Message
                    );
            }
        }



        // Event methods
#if __IOS__
        public void BeaconsWasRanged(object sender, CLRegionBeaconsRangedEventArgs e)
        {
            try
            {
                foreach (CLBeacon b in e.Beacons)
                {
                    UpdateBeacon(b);

                } // foreach

            CheckClosestBeacon();


            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconController.BeaconsWasRanged()",
                    ex.Message
                    );
            }

        }
#endif

        public void CheckClosestBeacon()
        {
            try
            {
                // Make them refresh before checking them
                beacons.ForEach(w =>
                {
                    w.CheckAnnouncement();

                });

                var beacons_at = beacons.Where(w =>
                                               w.LastUpdated > DateTime.Now.AddSeconds(-4) &&
                                               w.DistanceState >= NodeDistanceState.At &&
                                               w.Nodes.Any()
                                              ).OrderBy(w => -w.Rssi);

                if (currently_at != null)
                {
                    if (currently_at.DistanceState >= NodeDistanceState.At)
                    {
                        // Not sticky
                        left_at = null;

                        var thesearecloser = beacons_at.Where(w => w.Rssi > currently_at.Rssi + 3);
                        if (thesearecloser.Any())
                        {
                            currently_at = thesearecloser.First();
                            MakeOthersAwareAboutCurrentlyAt(currently_at);

                        } // A new beacon was closer

                    } // Is At
                    else
                    {
                        // The currently at won't be in the bunch
                        if (beacons_at.Any())
                        {
                            left_at = null;
                            currently_at = beacons_at.First();
                            MakeOthersAwareAboutCurrentlyAt(currently_at);

                        } // A new beacon is closer
                        else if (!left_at.HasValue)
                        {
                            // The current beacon is not At anymore so start the sticy time
                            left_at = DateTime.Now;

                        } // Sticky time started
                        else if (DateTime.Now > left_at.Value.AddSeconds(StickySeconds))
                        {
                            left_at = null;
                            currently_at = null;
                            MakeOthersAwareAboutCurrentlyAt(currently_at);

                        } // Not sticky anymore

                    } // Not At

                } // Currently At not null
                else
                {
                    if (beacons_at.Any())
                    {
                        left_at = null;
                        currently_at = beacons_at.First();
                        MakeOthersAwareAboutCurrentlyAt(currently_at);

                    } // A new beacon is At

                } // currently_at is null


            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconController.CheckClosestBeacon()",
                    ex.Message
                    );
            }
        }

        protected void BeaconWasUpdated(object sender, EventArgs e)
        {
            try
            {
                BLEBeacon b = sender as BLEBeacon;

                if (b == null)
                {
                    return;

                }

                b.CheckAnnouncement();

                if (OnBeaconUpdated != null)
                {
                    OnBeaconUpdated(this, b);

                }


            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconWasUpdated()",
                    ex.Message
                    );

            }

        } // BeaconWasUpdated

        protected void BeaconMadeAnnouncement(object sender, NodeAnnouncementEventArgs args)
        {
            try
            {
                if (OnBeaconMadeAnnouncement != null)
                {
                    BLEBeacon b = sender as BLEBeacon;
                    OnBeaconMadeAnnouncement(b, args);
                }

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconMadeAnnouncement()",
                    ex.Message
                    );

            }

        } // BeaconMadeAnnouncement

        protected void BeaconDistanceStateChanged(object sender, NodeDistanceState newState)
        {
            try
            {
                if (OnBeaconDistanceStateChanged != null)
                {
                    OnBeaconDistanceStateChanged(sender, newState);

                }

            }
            catch (Exception ex)
            {
                LogCenter.Error(
                    "BeaconDistanceStateChanged()",
                    ex.Message
                    );
            }
        }

        public void StartMonitoringWaypointType(string waypointType)
        {
            try
            {
                SQLiteConnection db = SQLiteController.Me.Db;
                var nodes = (
                    from x in db.Table<CacheNodeBeacon>()
                    where x.WaypointType == waypointType
                    select x
                    );

                foreach (CacheNodeBeacon cnb in nodes)
                {
                    BLEBeacon b = new BLEBeacon()
                    {
                        Uuid = cnb.Uuid,
                        Major = cnb.Major,
                        Minor = cnb.Minor
                    };
#if __IOS__
                    CLRegion region = b.GetRegion(RegionMask.UuidMajorMinor);
                    if (region != null)
                    {
                        region.NotifyOnEntry = true;
                        region.NotifyOnExit = false;
                        locman.StartMonitoring(region);

                    } // region not null
#endif
#if __ANDROID__
#endif

                } // foreach

            }
            catch (Exception ex)
            {
                LogCenter.Error("StartMonitoringWaypointType()", ex.Message);

            }

        }


        // Properties
        public static BeaconController Me
        {
            get
            {
                if (me == null)
                {
                    me = new BeaconController();

                }

                return me;

            } // get

        } // Me

#if __ANDROID__
        public static Context Ctx { get; set; }
#endif

        public BLEBeacon[] Beacons
        {
            get
            {
                return beacons.ToArray();

            } // get

        } // Beacons

        public string[] Uuids
        {
            get
            {
                return uuids.ToArray();

            } // get

        } // Uuids

        public BLEBeacon CurrentlyAt
        {
            get
            {
                return currently_at;
            }
        }

        public event EventHandler<BLEBeacon> OnBeaconAdded;
        public event EventHandler<BLEBeacon> OnBeaconRemoved;
        public event EventHandler<BLEBeacon> OnBeaconUpdated;

        public event EventHandler<NodeAnnouncementEventArgs> OnBeaconMadeAnnouncement;
        public event EventHandler<BLEBeacon> BeaconAtHasChanged;
        public event EventHandler<NodeDistanceState> OnBeaconDistanceStateChanged;


    } // class

#if __IOS__
    public class CbCentralDelegate : CBCentralManagerDelegate
    {
        public override void UpdatedState(CBCentralManager central)
        {
            if (central.State == CBCentralManagerState.PoweredOn)
            {
                System.Console.WriteLine("Powered On");
            }
        }
    }
#endif


}