using Kwenda.Models;
using Kwenda;
using System;
using System.Linq;
using System.Text;
using WayfindR.Controllers;
using WayfindR.Helpers;
#if __IOS__
using CoreLocation;
#endif

namespace WayfindR.Models
{
    public partial class BLEBeacon
    {
        private CacheNodeBeacon[] cnbs;
        private bool inrangeread;
        private bool closebyread;
        private bool descriptionread;
        //tmp private int? lastdescheading;
        private WFHeadingInfo lastheadinginfo;
        private WFHeadingInfo[] hinfos = new WFHeadingInfo[360];
        private NodeDistanceState diststate;
        

        private bool touched;

        public const int HEADING_OFFSET = 15;
        public const double TouchAccuracy = 0.2;
        



		public BLEBeacon(string uuid, int major, int minor)
        {            
            this.Major = major;
            this.Minor = minor;
            
        }

#if __IOS__
		public BLEBeacon(CLBeacon aBeacon) : this()
		{
			this.Uuid = aBeacon.ProximityUuid.ToString().ToLower();
			this.Major = (int)aBeacon.Major;
			this.Minor = (int)aBeacon.Minor;

		}
#endif
        private void InitHeadingInfos()
        {
            CacheNodeBeacon cnb = this.Nodes.FirstOrDefault();
            if (cnb == null)
            {
                return;

            } // No cache node

            WFNode n = cnb.Node;
            if (n == null)
            {
                return;

            } // No node


            foreach (WFHeadingInfo hi in n.HeadingInfos)
            {
                for (int i = hi.Heading - HEADING_OFFSET; i <= hi.Heading + HEADING_OFFSET; i++)
                {
                    hinfos[HeadingHelper.ValidHeading(i)] = hi;

                } // for
                                
            }

        }


        public void CheckAnnouncement()
        {
            CacheNodeBeacon cnb = Nodes.FirstOrDefault();
            if (cnb == null)
            {
				if (!touched)
				{
					if (this.Distance <= TouchAccuracy &&
					   this.Distance >= 0.0)
					{
                        diststate = NodeDistanceState.Touch;
                        if (OnDistanceStateChanged != null)
                        {
                            OnDistanceStateChanged(this, DistanceState);

                        }

                        if (OnAnnouncement != null)
						{
							NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs ();
							args.DistanceState = NodeDistanceState.Touch;
                            args.Message = string.Empty;
                            args.Kind = NodeAnnouncementKind.Other;
							OnAnnouncement (this, args);

						}
						touched = true;

					}

				}
				else
				{
					if (this.Distance > TouchAccuracy)
					{
						touched = false;
                        diststate = NodeDistanceState.At;
                        if (OnDistanceStateChanged != null)
                        {
                            OnDistanceStateChanged(this, DistanceState);

                        }

                    }

				} // touched

				return;

            }

            WFNode n = cnb.Node;

            if (n == null)
            {
                return;

            }
                        

            if (!this.InRange())
            {
                diststate = NodeDistanceState.OutOfRange;
                if (OnDistanceStateChanged != null)
                {
                    OnDistanceStateChanged(this, DistanceState);

                }

                if (OnAnnouncement != null)
                {
                    NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                    args.DistanceState = this.DistanceState;
                    args.Message = n.OutOfRangeMessage;
                    args.Kind = NodeAnnouncementKind.Other;
                    OnAnnouncement(this, args);

                }

                return;

            } // not in range

            if (!inrangeread)
            {
                if (this.Distance <= n.InRangeAccuracy)
                {
                    diststate = NodeDistanceState.InRange;
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.DistanceState = this.diststate;
                        args.Message = n.InRangeMessage;
                        args.Kind = NodeAnnouncementKind.Other;
                        OnAnnouncement(this, args);

                    }

                    inrangeread = true;

                }

            } // not announced
            else
            {
                if (this.Distance > n.InRangeAccuracy)
                {
                    inrangeread = false;
                    diststate = NodeDistanceState.OutOfRange;
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.DistanceState = this.diststate;
                        args.Message = n.OutOfRangeMessage;
                        args.Kind = NodeAnnouncementKind.Other;
                        OnAnnouncement(this, args);

                    }

                }
                    
            } // in range read


            if (!closebyread)
            {
                if (this.Distance <= n.CloseByAccuracy)
                {
                    diststate = NodeDistanceState.CloseBy;
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.DistanceState = this.diststate;
                        args.Message = n.CloseByMessage;
                        args.Kind = NodeAnnouncementKind.Other;
                        OnAnnouncement(this, args);

                    }
                    closebyread = true;

                }

            }
            else
            {
                if (this.Distance > n.CloseByAccuracy)
                {
                    closebyread = false;

                    if (this.Distance <= n.InRangeAccuracy)
                    {
                        diststate = NodeDistanceState.InRange;

                    }
                    else
                    {
                        diststate = NodeDistanceState.OutOfRange;

                    }
                    
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                }

            } // close by read

            
			if (!descriptionread)
            {
                if (this.Distance <= n.Accuracy)
                {

                    if (diststate != NodeDistanceState.At &&
                        OnDistanceStateChanged != null)
                    {
                        diststate = NodeDistanceState.At;
                        OnDistanceStateChanged(this, NodeDistanceState.At);

                    }
                    
                    diststate = NodeDistanceState.At;

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.DistanceState = this.diststate;
                        args.Message = string.Empty;
                        args.Kind = NodeAnnouncementKind.Other;

                        if (!descriptionread)
                        {
                            args.Message = n.DescriptiveName;

                        } // not already read
                        
                        
                        if (!string.IsNullOrEmpty(args.Message))
                        {
                            OnAnnouncement(this, args);

                        } // There is a message

                    } // Event is assigned

                    descriptionread = true;

                } // Less than distance

            }
            else
            {
                if (this.Distance > n.Accuracy)
                {
                    descriptionread = false;
                    lastheadinginfo = null;

                    if (this.Distance <= n.CloseByAccuracy)
                    {
                        diststate = NodeDistanceState.CloseBy;

                    }
                    else if (this.Distance <= n.InRangeAccuracy)
                    {
                        diststate = NodeDistanceState.InRange;

                    }
                    else
                    {
                        diststate = NodeDistanceState.OutOfRange;

                    }
                                        
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                } // Greater than distance

            } // description read


            // Check if we have any heading dependant messages and we're
            // At and in that case read that message.
            if (n.HeadingInfos.Any() &&
                this.IsAt())
            {
                if (OnAnnouncement != null)
                {
                    NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                    args.DistanceState = this.diststate;
                    args.Message = string.Empty;
                    args.Kind = NodeAnnouncementKind.HeadingInfo;

					int currentheading = HeadingHelper.CurrentHeading(n.MagneticOffset);
                    WFHeadingInfo hi = hinfos[currentheading];

                    if (hi != null)
                    {
                        if (lastheadinginfo == null ||
                            (lastheadinginfo != null &&
                            lastheadinginfo != hi)
                           )
                        {
                            //karl-otto
                            args.Message += hi.Info;
                            args.Data = hi;
                            lastheadinginfo = hi;

                            OnAnnouncement(this, args);

                        } // is a different heading

                    } // A heading that has a message
                    else
                    {
                        if (lastheadinginfo != null)
                        {
                            lastheadinginfo = null;

                            OnAnnouncement(this, args);

                        } // not null

                    } // else hi not null
                    
                    
                } // Event is assigned


            } // IsAt()



            if (!touched)
            {
                if (this.Distance <= TouchAccuracy)
                {
                    diststate = NodeDistanceState.Touch;
                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);

                    }

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.DistanceState = this.diststate;
                        args.Message = n.TouchMessage;
                        args.Kind = NodeAnnouncementKind.Other;
                        OnAnnouncement(this, args);

                    }
                    touched = true;

                }

            }
            else
            {
                if (this.Distance > TouchAccuracy)
                {
                    touched = false;
                    diststate = NodeDistanceState.At;

                    if (OnDistanceStateChanged != null)
                    {
                        OnDistanceStateChanged(this, DistanceState);
                        
                    }

                }

            } // touched


        }
        

		public bool IsAt()
		{
			bool result = DistanceState >= NodeDistanceState.At;

            return result;

		}
        
		public CacheNodeBeacon RelevantNode()
		{
			CacheNodeBeacon cnb = Nodes.FirstOrDefault ();
			if (cnb != null &&
			    cnb.Node != null)
			{
                cnb.Beacon = this;
				return cnb;

			}

			return null;

		}


        public NodeDistanceState DistanceState
        {
            get
            {
                return diststate;
            } // get
			set
			{
				diststate = value;
			}
        } // DistanceState
        public CacheNodeBeacon[] Nodes
        {
            get { return cnbs; }
            set
            {
                cnbs = value;
                InitHeadingInfos();
            } // set

        } // Nodes
        
        
        public event EventHandler<NodeAnnouncementEventArgs> OnAnnouncement;
        public event EventHandler<NodeDistanceState> OnDistanceStateChanged;
        
    } // class

    public class NodeAnnouncementEventArgs : EventArgs
    {
        public NodeDistanceState DistanceState { get; set; }
        public string Message { get; set; }
        public int? Heading { get; set; }
        public NodeAnnouncementKind Kind { get; set; }
        public object Data { get; set; }


    } // class

    public enum NodeAnnouncementKind
    {
        Other,
        HeadingInfo
    } // enum


    public enum NodeDistanceState
    {
		OutOfRange,
        InRange,
        CloseBy,
        At,
        Touch

    } // enum

}
