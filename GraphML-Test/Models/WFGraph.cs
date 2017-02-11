using QuickGraph;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;
using System.Xml.Linq;
using System.Reflection;
using System.Globalization;

namespace WayfindR.Models
{
    [Serializable]
    public class WFGraph : AdjacencyGraph<WFNode, WFEdge<WFNode>>
    {        

        public string Id { get; set; }

        [XmlAttribute("graph_id")]
        public string GraphId { get; set; }

        [XmlAttribute("venue_id")]
        public string VenueId { get; set; }

        [XmlAttribute("venue_name")]
        public string VenueName{ get; set; }

        [XmlAttribute("graph_level")]
        public int Level { get; set; }




        public WFGraph()
        {
        }


        private static Dictionary<string, string> MakeDictionaryOfTheseElements(IEnumerable<XElement> dataElements, List<GraphMLKey> gKeys)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (XElement data in dataElements)
            {
                string name = NodeAttribute(data, "key");
                string val = data.Value;

                GraphMLKey gk = gKeys.Where(w => w.Id == name).FirstOrDefault();
                if (gk != null)
                {
                    name = gk.Name;
                    if (string.IsNullOrEmpty(val))
                    {
                        val = gk.DefaultValue;

                    } // No value

                } // gk not null

                if (!string.IsNullOrEmpty(name))
                {
                    result[name] = val;

                }
                

            } // foreach

            return result;

        }

        public static bool TryGetAttributeName(PropertyInfo property, out string name)
        {
            var attribute = Attribute.GetCustomAttribute(property, typeof(XmlAttributeAttribute))
                as XmlAttributeAttribute;
            if (attribute == null)
            {
                name = null;
                return false;
            }
            else
            {
                if (String.IsNullOrEmpty(attribute.AttributeName))
                {
                    name = property.Name;
                }
                else
                {
                    name = attribute.AttributeName;

                }

                return true;
            }
        }


        private static void SetPropertyValues(object obj, Dictionary<string, string> dataDict)
        {
            try
            {
                Type currentType = obj.GetType();

                foreach (PropertyInfo prop in currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {                    
                    if (!prop.CanWrite || prop.GetIndexParameters().Length > 0)
                    {
                        continue;

                    }

                    string propname = prop.Name;
                    
                    // Is it tagged with XmlAttributeAttribute?
                    string xmlname;
                    if (TryGetAttributeName(prop, out xmlname))
                    {
                        propname = xmlname;
                                                
                    } // XmlAttr

                    if (dataDict.ContainsKey(propname))
                    {
                        try
                        {
                            string sval = dataDict[propname];

                            if (prop.PropertyType == typeof(int))
                            {
                                int ival;
                                if (int.TryParse(sval, out ival))
                                {
                                    prop.SetValue(obj, ival);

                                }                                

                            }
                            else if (prop.PropertyType == typeof(double))
                            {
                                double dval;
                                if (double.TryParse(
                                    sval, 
                                    NumberStyles.Number | NumberStyles.AllowDecimalPoint,
                                    CultureInfo.CreateSpecificCulture("en-US"),
                                    out dval))
                                {
                                    prop.SetValue(obj, dval);

                                }
                            }
                            else
                            {
                                prop.SetValue(obj, dataDict[propname]);

                            }
                            

                        }
                        catch
                        {
                            string nils = "";
                        }
                        

                    } // Found in dictionary


                } // foreach


            }
            catch (Exception ex)
            {
                throw;

            }

        }




        private static string NodeValue(XElement node, string nodeName, XNamespace ns)
        {
            if (node == null)
            {
                return "";

            }

            XElement valnode = node.Element(ns + nodeName);
            if (valnode == null)
            {
                return "";

            }

            return valnode.Value;

        }

        private static string SubNodeValue(XElement node, string nodeName, string subNodeName, XNamespace ns)
        {
            if (node == null)
            {
                return "";

            }

            XElement childnode = node.Element(ns + nodeName);
            if (childnode == null)
            {
                return "";

            }

            XElement subnode = childnode.Element(ns + subNodeName);
            if (subnode == null)
            {
                return "";
            }

            return subnode.Value;

        }


        private static string NodeAttribute(XElement node, string attribName)
        {
            if (node == null)
            {
                return "";

            }

            XAttribute attrib = node.Attribute(attribName);
            if (attrib == null)
            {
                return "";

            }

            return attrib.Value;

        }


        public static WFGraph LoadFromGraphML(Stream stream)
        {
            try
            {
                WFGraph result = null;
                List<GraphMLKey> gklist = new List<GraphMLKey>();

                XDocument xdoc = XDocument.Load(stream);
                XElement xroot = xdoc.Root;
                XNamespace ns = xroot.GetDefaultNamespace();
                
                // Attributes
                var attrkeys = xroot.Elements(ns + "key");

                foreach (XElement attrkey in attrkeys)
                {
                    GraphMLKey gk = new GraphMLKey()
                    {
                        Name = NodeAttribute(attrkey, "attr.name"),
                        DataType = NodeAttribute(attrkey, "attr.type"),
                        Id = NodeAttribute(attrkey, "id"),
                        ForType = NodeAttribute(attrkey, "for"),
                        DefaultValue = NodeValue(attrkey, "default", ns)
                    }; // new

                    gklist.Add(gk);

                } // foreach attribute key

                XElement xgraph = xroot.Element(ns + "graph");
                if (xgraph != null)
                {
                    result = new WFGraph();
                    
                    // Graph properties
                    var xgdata = xgraph.Elements(ns + "data");
                    SetPropertyValues(result, MakeDictionaryOfTheseElements(xgdata, gklist));

                    // Nodes
                    Dictionary<string, WFNode> gnodes = new Dictionary<string, WFNode>();
                    var xnodes = xgraph.Elements(ns + "node");
                    foreach (XElement xnode in xnodes)
                    {
                        string nid = NodeAttribute(xnode, "id");
                        WFNode wfn = new WFNode(nid);

                        var xndata = xnode.Elements(ns + "data");
                        SetPropertyValues(wfn, MakeDictionaryOfTheseElements(xndata, gklist));

                        result.AddVertex(wfn);
                        gnodes[nid] = wfn;

                    } // foreach xnode


                    // Edges
                    var xedges = xgraph.Elements(ns + "edge");
                    foreach (XElement xedge in xedges)
                    {
                        string eid = NodeAttribute(xedge, "id");
                        string src = NodeAttribute(xedge, "source");
                        string tgt = NodeAttribute(xedge, "target");
                        WFNode srcnode = gnodes[src];
                        WFNode tgtnode = gnodes[tgt];

                        WFEdge<WFNode> wfe = new WFEdge<WFNode>(srcnode, tgtnode, eid);

                        var xedata = xedge.Elements(ns + "data");
                        SetPropertyValues(wfe, MakeDictionaryOfTheseElements(xedata, gklist));

                        result.AddEdge(wfe);

                    } // foreach xedge
                    
                } // if xgraph not null
                
                    return result;
                
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


        public WFNode FindNode(CacheNodeBeacon cnb)
        {
            if (cnb == null)
            {
                return null;

            } // cnb is null

            WFNode result = this.Vertices.Where(w => w.Major == cnb.Major && w.Minor == cnb.Minor).FirstOrDefault();

            return result;

        }


    } // class WFGraph


    public class GraphMLKey
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string ForType { get; set; }
        public string DefaultValue { get; set; }


    } // GraphMLKey

}
