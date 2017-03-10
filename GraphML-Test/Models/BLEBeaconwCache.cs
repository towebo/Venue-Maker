using CoreLocation;
using System;
using System.Linq;
using System.Text;
using WayfindR.Controllers;
using WayfindR.Helpers;

namespace WayfindR.Models
{
    public partial class BLEBeacon
    {
        private CacheNodeBeacon[] cnbs;
        private bool inrangeread;
        private bool closebyread;
        private bool descriptionread;
        private int? lastdescheading;
        private WFHeadingInfo[] hinfos = new WFHeadingInfo[360];

        private bool touched;

        public const int HEADING_OFFSET = 15;
        public const double TouchAccuracy = 0.2;



        public BLEBeacon(CLBeacon aBeacon)            : this()
        {            
            this.Major = (int)aBeacon.Major;
            this.Minor = (int)aBeacon.Minor;
            
        }

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
					if (this.Distance <= TouchAccuracy)
					{
						if (OnAnnouncement != null)
						{
							NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs ();
							args.AnnouncementType = NodeAnnouncementType.Touch;
							args.Message = "";
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
                if (OnAnnouncement != null)
                {
                    NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                    args.AnnouncementType = NodeAnnouncementType.OutOfRange;
                    args.Message = n.OutOfRangeMessage;
                    OnAnnouncement(this, args);

                }

                return;

            } // not in range

            if (!inrangeread)
            {
                if (this.Distance <= n.InRangeAccuracy)
                {
                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.AnnouncementType = NodeAnnouncementType.InRange;
                        args.Message = n.InRangeMessage;
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

                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.AnnouncementType = NodeAnnouncementType.OutOfRange;
                        args.Message = n.OutOfRangeMessage;
                        OnAnnouncement(this, args);

                    }

                }
                    
            } // in range read


            if (!closebyread)
            {
                if (this.Distance <= n.CloseByAccuracy)
                {
                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.AnnouncementType = NodeAnnouncementType.Description;
                        args.Message = n.CloseByMessage;
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

                }

            } // close by read

            
            if (!descriptionread ||
                n.HeadingInfos.Any())
            {
                if (this.Distance <= n.Accuracy)
                {
                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.AnnouncementType = NodeAnnouncementType.Description;
                        args.Message = "";

                        if (!descriptionread)
                        {
                            args.Message = n.DescriptiveName;

                        } // not already read


                        int currentheading = HeadingHelper.CurrentHeading();
                        WFHeadingInfo hi = hinfos[currentheading];

                        if (hi != null)
                        {
                            if (!lastdescheading.HasValue ||
                                lastdescheading.Value != hi.Heading)
                            {
                                args.Message += hi.Info;
                                lastdescheading = hi.Heading;

                            } // is a different heading

                        } // A heading that has a message
                        
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
                {                    descriptionread = false;
                    lastdescheading = null;

                } // Greater than distance

            } // description read


            if (!touched)
            {
                if (this.Distance <= TouchAccuracy)
                {
                    if (OnAnnouncement != null)
                    {
                        NodeAnnouncementEventArgs args = new NodeAnnouncementEventArgs();
                        args.AnnouncementType = NodeAnnouncementType.Touch;
                        args.Message = n.TouchMessage;
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

                }

            } // touched


        }
        


		public CacheNodeBeacon RelevantNode()
		{
			CacheNodeBeacon cnb = Nodes.FirstOrDefault ();
			if (cnb != null &&
			    cnb.Node != null)
			{
				return cnb;

			}

			return null;

		}


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
        
    } // class

    public class NodeAnnouncementEventArgs : EventArgs
    {
        public NodeAnnouncementType AnnouncementType { get; set; }
        public string Message { get; set; }
        public int? Heading { get; set; }

    } // class

    public enum NodeAnnouncementType
    {
        InRange,
        OutOfRange,
        Close,
        Description,
        Touch

    } // enum

}
