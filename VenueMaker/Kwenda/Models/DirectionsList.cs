using Kwenda;
using Mawingu;
using System.Collections.Generic;
using System.Text;
using WayfindR.Helpers;

namespace WayfindR.Models
{
    public class DirectionsList
    {
        private List<DirectionItem> diritems;
        private IEnumerable<WFEdge<WFNode>> route;


        public DirectionsList()
        {
            diritems = new List<DirectionItem>();
            route = new List<WFEdge<WFNode>>();

    }

        public DirectionsList(IEnumerable<WFEdge<WFNode>> calculatedRoute)
            : this()
        {
            if (calculatedRoute != null)
            {
                SetDirections(calculatedRoute);

            }

        }

        


        public void SetDirections(IEnumerable<WFEdge<WFNode>> calculatedRoute)
        {
            route = calculatedRoute;

			diritems.Clear();
			if (calculatedRoute != null)
			{
				foreach (WFEdge<WFNode> edge in calculatedRoute)
				{
					DirectionItem di = new DirectionItem();
					di.Edge = edge;

					diritems.Add(di);

				} // foreach

			} // dirs not null

            if (diritems.Count > 0)
            {
                WFEdge<WFNode> firstedge = diritems[0].Edge;
                
                DirectionItem startdi = new DirectionItem();
                startdi.Node = firstedge.Source;
                diritems.Insert(0, startdi);

                WFEdge<WFNode> lastedge = diritems[diritems.Count - 1].Edge;

                DirectionItem enddi = new DirectionItem();
                enddi.Node = lastedge.Target;
                diritems.Add(enddi);


            } // Contains anything

            for (int i = 0; i < diritems.Count; i++)
            {
                if (i >= 1)
                {
                    diritems[i].PreviousItem = diritems[i - 1];
                }
                if (i < diritems.Count - 1)
                {
                    diritems[i].NextItem = diritems[i + 1];

                }               

            } // for

        }


        public DirectionItem[] Directions
        {
            get
            {
                return diritems.ToArray();
            }

        }

        public IEnumerable<WFEdge<WFNode>> Route
        {
            get
            {
                return route;
            } // get
        } // Route


    } // class

    public class DirectionItem
    {
        public WFEdge<WFNode> Edge { get; set; }
        public WFNode Node { get; set; }
        public DirectionItem PreviousItem { get; set; }
        public DirectionItem NextItem { get; set; }



		public DirectionItemType ItemType
		{
			get
			{
				if (PreviousItem == null)
				{
					return DirectionItemType.Start;

				}
				else if (NextItem == null)
				{
					return DirectionItemType.Destination;

				}
				else
				{
					return DirectionItemType.Waypoint;

				}
				
			} // get

		} // ItemType


		public HeadingHelper.NaturalDirection NaturalDirection 
		{
			get
			{
				if ((PreviousItem == null ||
				     PreviousItem.Edge == null) &&
				    Edge != null)
				{
					return HeadingHelper.NaturalDirection.StraightAhead;
				}

				if (PreviousItem == null ||
				   PreviousItem.Edge == null ||
				    Edge == null)
				{
					return HeadingHelper.NaturalDirection.Unknown;

				}

				int th = HeadingHelper.TurnHeading(
					PreviousItem.Edge.EndHeading,
					Edge.StartHeading
					);

				return HeadingHelper.NaturalTurn(th);

			} // get

		} // NaturalDirection



        public string Text
        {
            get
            {
                StringBuilder txt = new StringBuilder();

                if (Node != null)
                {
					if (this.ItemType == DirectionItemType.Start)
					{
						txt.Append(Node.Name);
						
					}
					else if (this.ItemType == DirectionItemType.Destination)
					{
						txt.Append(Node.Name);

					}
					else
					{
						txt.Append(Node.Name);

					}

                    return txt.ToString();

                }

                
                if (PreviousItem != null &&
				    PreviousItem.Edge != null)
                {
					//HeadingHelper.ClockwizeDirection cd = HeadingHelper.ClockwizeTurn(th);
					//string strturn = HeadingHelper.ClockwizeDirectionName(cd);

					HeadingHelper.NaturalDirection nd = this.NaturalDirection;
                    string strturn = HeadingHelper.NaturalDirectionName(nd);

                    if (nd == HeadingHelper.NaturalDirection.StraightAhead)
                    {
                        txt.Append("Continue straight ahead".Translate());

                    }
                    else if (nd == HeadingHelper.NaturalDirection.TurnAround)
                    {
                        txt.Append("Turn around".Translate());

                    }
                    else
                    {
                        txt.Append(string.Format("Turn {0}".Translate(),
                            strturn.ToLower()
                            ));

                    }

                    txt.Append(", ");

                } // Previous item not null
                
                
                txt.Append(Edge.Beginning);

                return txt.ToString();

            } // get

        } // txt

    } // class

	public enum DirectionItemType
	{
		Start,
		Waypoint,
		Destination
	}


}
