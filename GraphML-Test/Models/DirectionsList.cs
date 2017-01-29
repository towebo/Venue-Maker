using System.Collections.Generic;
using WayfindR.Helpers;

namespace WayfindR.Models
{
    public class DirectionsList
    {
        private List<DirectionItem> diritems;


        public DirectionsList()
        {
            diritems = new List<DirectionItem>();
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
            diritems.Clear();
            foreach (WFEdge<WFNode> edge in calculatedRoute)
            {
                DirectionItem di = new DirectionItem();
                di.Edge = edge;

                diritems.Add(di);

            } // foreach

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
    }

    public class DirectionItem
    {
        public WFEdge<WFNode> Edge { get; set; }
        public DirectionItem PreviousItem { get; set; }
        public DirectionItem NextItem { get; set; }

        public string Text
        {
            get
            {
                string txt = Edge.Beginning;
                if (PreviousItem != null)
                {
                    int th = HeadingHelper.TurnHeading(
                        PreviousItem.Edge.EndHeading,
                        Edge.StartHeading
                        );


                    //HeadingHelper.ClockwizeDirection cd = HeadingHelper.ClockwizeTurn(th);
                    //string strturn = HeadingHelper.ClockwizeDirectionName(cd);

                    HeadingHelper.NaturalDirection nd = HeadingHelper.NaturalTurn(th);
                    string strturn = HeadingHelper.NaturalDirectionName(nd);

                    if (nd == HeadingHelper.NaturalDirection.StraightAhead)                        
                    {
                        strturn = "Fortsätt " + strturn;

                    }
                    else if (nd != HeadingHelper.NaturalDirection.TurnAround)
                    {
                        strturn = "Vänd " + strturn;

                    }

                    txt = strturn + ", " + txt;
                }
                else
                {
                    //txt = Edge.StartHeading.ToString() + " " + txt;
                }

                if (NextItem != null)
                {
                    //txt += " " + NextItem.Edge.StartHeading.ToString();

                }

                return txt;

            } // get

        } // txt

    }
}
