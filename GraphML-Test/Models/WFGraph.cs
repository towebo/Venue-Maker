using QuickGraph;
using QuickGraph.Serialization.Mawingu;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;

namespace WayfindR.Models
{
    [Serializable]
    public class WFGraph : AdjacencyGraph<WFNode, WFEdge<WFNode>>
    {
        public string Id { get; set; }

        [XmlAttribute("venue_id")]
        public string VenueId { get; set; }

        [XmlAttribute("venue_name")]
        public string VenueName{ get; set; }

        [XmlAttribute("graph_level")]
        public int Level { get; set; }
        

        public static WFGraph LoadFromGraphML(Stream stream)
        {
            try
            {
                WFGraph result = new WFGraph();

                

                using (var xreader = XmlReader.Create(stream))
                {
                    try
                    {
                            result.DeserializeFromGraphML(xreader,
                            (id) => new WFNode(id),
                            (source, target, id) => new WFEdge<WFNode>(source, target, id)
                            );
                        

                        return result;

                    }
                    finally
                    {
                        xreader.Close();
                    } // try

                } // using


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public WFNode[] GetNodesAlphabetical()
        {
            WFNode[] nodesalpha = (
                from x in Vertices
                orderby x.Name
                select x
                ).ToArray();
            return nodesalpha;
        }


        public IEnumerable<WFEdge<WFNode>> CalculateRoute(WFNode source, WFNode target)
        {
            IEnumerable<WFEdge<WFNode>> path;

            Func<WFEdge<WFNode>, double> edgeCost = w => w.TravelTime;

            DijkstraShortestPathAlgorithm<WFNode, WFEdge<WFNode>> dijkstra = new DijkstraShortestPathAlgorithm<WFNode, WFEdge<WFNode>>(
                this,
                edgeCost
                );
            VertexDistanceRecorderObserver<WFNode, WFEdge<WFNode>> distObserver = new VertexDistanceRecorderObserver<WFNode, WFEdge<WFNode>>(edgeCost);
            using (distObserver.Attach(dijkstra))
            {
                // Attach a Vertex Predecessor Recorder Observer to give us the paths
                VertexPredecessorRecorderObserver<WFNode, WFEdge<WFNode>> predecessorObserver = new VertexPredecessorRecorderObserver<WFNode, WFEdge<WFNode>>();
                using (predecessorObserver.Attach(dijkstra))
                {
                    dijkstra.Compute(source);

                    /*
                    foreach (KeyValuePair<WFNode, WFEdge<WFNode>> kvp in predecessorObserver.VertexPredecessors)
                    {
                        Console.WriteLine("If you want to get to {0} you have to enter through the in edge {1}", kvp.Key, kvp.Value);

                    } // foreach
                    */
                    
                    bool success = predecessorObserver.TryGetPath(
                        target,
                        out path
                        );

                } // using predecessor
                
            } // using distance observer

            
            

            return path;

        }

    }

}
