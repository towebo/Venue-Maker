using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayfindR.Models;

namespace VenueMaker.Models
{
    public class EdgeForPOI
    {
        public WFEdge<WFNode> Edge { get; set; }
        public string TextInList
        {
            get
            {
                string txt = "Unnamed";
                if (Edge == null)
                {
                    return txt;

                } // No edge

                WFNode src = Edge.Source as WFNode;
                string srctxt = src.Name;
                if (!string.IsNullOrWhiteSpace(src.Floor))
                {
                    srctxt = string.Format("{0} - {1}",
                        src.Floor,
                        src.Name
                        );
                }

                WFNode trgt = Edge.Target as WFNode;
                string trgttxt = trgt.Name;
                if (!string.IsNullOrWhiteSpace(trgt.Floor))
                {
                    trgttxt = string.Format("{0} - {1}",
                        trgt.Floor,
                        trgt.Name
                        );
                }

                txt = string.Format("{0} -> {1}, {2}",
                    srctxt,
                    trgttxt,
                    Edge.Beginning
                    );

                return txt;

            } // get

        } // TextInList
        

        public EdgeForPOI(WFEdge<WFNode> edge)
        {
            this.Edge = edge;

        }

        public static EdgeForPOI[] EdgesFor(WFEdge<WFNode>[] edges)
        {
            List<EdgeForPOI> items = new List<EdgeForPOI>();

            foreach (WFEdge<WFNode> edg in edges)
            {
                items.Add(new EdgeForPOI(edg));

            } // foreach

            return items.ToArray();
        }

    }
}
