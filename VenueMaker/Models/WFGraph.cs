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
using WayfindR.Helpers;

namespace WayfindR.Models
{
    [Serializable]
    public class WFGraph : AdjacencyGraph<WFNode, WFEdge<WFNode>>
    {
        private static NumberFormatInfo nfi = new NumberFormatInfo();
        private List<GraphMLKey> graphmlkeys;


        public const string GraphMLNameSpace = "http://graphml.graphdrawing.org/xmlns";



        public Int64 LastEdgeId
        {
            get
            {
                Int64 result = 0;
                if (Edges.Count() > 0)
                {
                    result = (
                        from x in Edges
                        select Convert.ToInt64(x.Id.NumbersOnly())
                        ).Max();
                } // Has edges
                return result;

            } // get
        } // LastEdgeId
        public Int64 LastNodeId
        {
            get
            {
                Int64 result = 0;
                if (Vertices.Count() > 0)
                {
                    result = (
                            from x in Vertices
                            select Convert.ToInt64(x.Id.NumbersOnly())
                            ).Max();
                } // Has nodes
                return result;
                                
            } // get
        } // LastNodeId

        

        public string Id { get; set; }

        [XmlAttribute("graph_id")]
        public string GraphId { get; set; }

        [XmlAttribute("venue_id")]
        public string VenueId { get; set; }

        [XmlAttribute("venue_name")]
        public string VenueName{ get; set; }

        [XmlAttribute("graph_level")]
        public int Level { get; set; }


        public List<GraphMLKey> GraphMLKeys
        {
            get { return graphmlkeys; }
        } // GraphMLKeys



        public WFGraph()
        {
            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            graphmlkeys = new List<GraphMLKey>();
            PopulateGraphMLKeys();

        }


        private void PopulateGraphMLKeys()
        {
            try
            {
                graphmlkeys.Clear();
                int gkid = 0;
                // Graph
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "venue_id",
                    DataType = "string",
                    ForType = "graph",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "venue_name",
                    DataType = "string",
                    ForType = "graph",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "level",
                    DataType = "int",
                    ForType = "graph",
                    DefaultValue = "3"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "graph_id",
                    DataType = "string",
                    ForType = "graph",
                    DefaultValue = ""
                });

                // Nodes
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "uuid",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "major",
                    DataType = "int",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "minor",
                    DataType = "int",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "id_tag",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "name",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "waypoint_type",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "floor",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "active",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = "true"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "accuracy",
                    DataType = "double",
                    ForType = "node",
                    DefaultValue = "3.5"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "name_descriptive",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "heading1info",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "heading2info",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "heading3info",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "heading4info",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "heading5info",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });

                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "in_range_accuracy",
                    DataType = "double",
                    ForType = "node",
                    DefaultValue = "60"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "in_range_message",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "touch_message",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "out_of_range_message",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "close_by_accuracy",
                    DataType = "double",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "close_by_message",
                    DataType = "string",
                    ForType = "node",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "magnetic_offset",
                    DataType = "int",
                    ForType = "node",
                    DefaultValue = "0"
                });

                // Edge
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "travel_time",
                    DataType = "double",
                    ForType = "edge",
                    DefaultValue = "15.0"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "travel_type",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "language",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "beginning",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "middle",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "end",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "starting_only",
                    DataType = "string",
                    ForType = "edge",
                    DefaultValue = ""
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "start_heading",
                    DataType = "int",
                    ForType = "edge",
                    DefaultValue = "-1"
                });
                graphmlkeys.Add(new GraphMLKey()
                {
                    Id = string.Format("d{0}", gkid++),
                    Name = "end_heading",
                    DataType = "int",
                    ForType = "edge",
                    DefaultValue = "-1"
                });
                

            }
            catch (Exception ex)
            {

            }

        }
        
        private static Dictionary<string, string> MakeDictionaryOfTheseElements(IEnumerable<XElement> dataElements, List<GraphMLKey> gKeys, string forType)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var mykeys = gKeys.Where(w => w.ForType == forType);
            foreach (GraphMLKey gkey in mykeys)
            {
                if (!string.IsNullOrEmpty(gkey.DefaultValue))
                {
                    result[gkey.Name] = gkey.DefaultValue;

                } // Has default value

            } // foreach

            if (dataElements != null)
            {
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

            } // if not null

            return result;

        }

        private static void MakeXelementsOfThese(Dictionary<string,string> propValues, XElement node, List<GraphMLKey> gKeys)
        {
            try
            {
                // Get all currently set properties
                var xdata = node.Elements(node.Name.Namespace + "data");

                foreach (string propName in propValues.Keys)
                {
                    GraphMLKey gkey = gKeys.Where(w => 
                        w.ForType == node.Name.LocalName &&
                        w.Name == propName
                        ).FirstOrDefault();

                    if (gkey == null)
                    {
                        continue;

                    } // No key present in graphml


                    XElement xdataelement = xdata.Where(w => NodeAttribute(w, "key") == gkey.Id).FirstOrDefault();
                    if (xdataelement != null)
                    {
                        if (gkey.DataType == "string")
                        {
                            xdataelement.ReplaceNodes(new XCData(propValues[propName]));
                        }
                        else
                        {
                            xdataelement.Value = propValues[propName];

                        } // else

                    }
                    else
                    {
                        if (propValues[propName] != gkey.DefaultValue &&
                            !string.IsNullOrEmpty(propValues[propName]))
                        {
                            xdataelement = new XElement(node.Name.Namespace + "data");
                            XAttribute xattr = new XAttribute("key", gkey.Id);
                            xdataelement.Add(xattr);
                            if (gkey.DataType == "string")
                            {
                                xdataelement.Add(new XCData(propValues[propName]));

                            }
                            else
                            {
                                xdataelement.Value = propValues[propName];

                            } // else
                            node.Add(xdataelement);

                        } // Not the default value
                        
                    } // No data element yet
                    
                } // foreach prop name
                
            }
            catch
            {
                throw;

            }

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
        
        private static Dictionary<string,string> GetPropertyValues(object obj)
        {
            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

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



                    string sval = string.Empty;
                    try
                    {
                        var val = prop.GetValue(obj);
                        if (val != null)
                        {
                            if (prop.PropertyType == typeof(double))
                            {
                                double dval = (double)val;
                                sval = dval.ToString(WFGraph.nfi);

                            } // double
                            else
                            {
                                sval = val.ToString();

                            } // else
                        }
                    }
                    catch
                    {
                    }
                    
                    result.Add(
                        propname,
                        sval
                        );
                                        

                } // foreach

                return result;

            }
            catch (Exception ex)
            {
                throw;

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

        public WFEdge<WFNode> NewEdge(WFNode source, WFNode target)
        {
            string id = string.Format("e{0}",
                    LastEdgeId + 1
                    );

            WFEdge<WFNode> result = new WFEdge<WFNode>(
                source,
                target,
                id
                );
                        
            result.Name = "New Edge";
            SetPropertyValues(
                            result,
                            MakeDictionaryOfTheseElements(
                                null,
                                graphmlkeys,
                                "edge"
                                ));

            return result;

        }

        public WFNode NewNode()
        {
            string id = string.Format("n{0}",
                    LastNodeId + 1
                    );

            WFNode result = new WFNode();
            result.Id = id;
            result.Name = "New Node";
            SetPropertyValues(
                            result,
                            MakeDictionaryOfTheseElements(
                                null,
                                graphmlkeys,
                                "node"
                                ));

            return result;

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

        public static WFGraph LoadFromGraphML(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (MemoryStream ms = new MemoryStream(
                        File.ReadAllBytes(fileName)
                        ))
                    {
                        WFGraph grph = WFGraph.LoadFromGraphML(ms);

                        return grph;
                        
                    } // using
                    
                } // File Exists

                return null;

            }
            catch
            {
                return null;


            }
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
                        yFilesType = NodeAttribute(attrkey, "yfiles.type"),
                        DefaultValue = NodeValue(attrkey, "default", ns)
                    }; // new
                    
                    gklist.Add(gk);

                } // foreach attribute key

                XElement xgraph = xroot.Element(ns + "graph");
                if (xgraph != null)
                {
                    result = new WFGraph();
                    result.graphmlkeys = gklist;

                    
                    // Graph properties
                    var xgdata = xgraph.Elements(ns + "data");
                    SetPropertyValues(
                        result, 
                        MakeDictionaryOfTheseElements(
                            xgdata, 
                            gklist,
                            xgraph.Name.LocalName
                            ));

                    // Nodes
                    Dictionary<string, WFNode> gnodes = new Dictionary<string, WFNode>();
                    var xnodes = xgraph.Elements(ns + "node");
                    foreach (XElement xnode in xnodes)
                    {
                        string nid = NodeAttribute(xnode, "id");
                        WFNode wfn = new WFNode(nid);

                        var xndata = xnode.Elements(ns + "data");
                        SetPropertyValues(
                            wfn, 
                            MakeDictionaryOfTheseElements(
                                xndata, 
                                gklist,
                                xnode.Name.LocalName
                                ));

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
                        SetPropertyValues(
                            wfe, 
                            MakeDictionaryOfTheseElements(
                                xedata, 
                                gklist,
                                xedge.Name.LocalName
                                ));

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
        
        public void Save(string fileName)
        {
            try
            {
                /*tmp
                if (!File.Exists(fileName))
                {
                    return;

                } // File Exists
                */

                /*tmp
                using (MemoryStream ms = new MemoryStream(
                        File.ReadAllBytes(fileName)
                        ))
                {*/
                    try
                    {
                        using (Stream ws = SaveToGraphML())
                        {
                            try
                            {

                                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                                {
                                    try
                                    {
                                        fs.SetLength(ws.Length);
                                        ws.Position = 0;
                                        ws.CopyTo(fs);
                                    }
                                    finally
                                    {
                                        fs.Close();

                                    }

                                } // using fs
                            }
                            finally
                            {
                                ws.Close();

                            }

                        } // using ws

                    }
                    finally
                    {
                        //tmp ms.Close();

                    }
                                        
                /*tmp
                } // using
                */

            }
            catch
            {
                throw;

            }

        }
        
        public Stream _SaveToGraphML(Stream stream)
        {
            try
            {                
                XDocument xdoc = XDocument.Load(stream);
                                                
                XElement xroot = xdoc.Root;
                XNamespace ns = xroot.GetDefaultNamespace();

                List<GraphMLKey> gklist = new List<GraphMLKey>();

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
                    // Graph properties
                    Dictionary<string, string> graphprops = GetPropertyValues(this);
                    MakeXelementsOfThese(graphprops, xgraph, gklist);


                    // Nodes
                    var xnodes = xgraph.Elements(ns + "node").ToArray();
                    
                    // Remove nodes that doesn't exist anymore
                    for (int idx = xnodes.Count() - 1; idx >= 0; idx--)
                    {
                        XElement xnode = xnodes[idx];
                        var node = this.Vertices.Where(w => w.Id == NodeAttribute(xnode, "id")).FirstOrDefault();
                        if (node == null)
                        {
                            xnode.Remove();

                        } // Not present

                    } // for

                    foreach (WFNode wfn in this.Vertices)
                    {
                        XElement xnode = xnodes.Where(w => NodeAttribute(w, "id") == wfn.Id).FirstOrDefault();
                        if (xnode == null)
                        {
                            xnode = new XElement(ns + "node");
                            XAttribute xattr = new XAttribute("id", wfn.Id);
                            xnode.Add(xattr);

                            xgraph.Add(xnode);

                        } // Node not in graphml
                        
                        Dictionary<string, string> nodeprops = GetPropertyValues(wfn);
                        MakeXelementsOfThese(nodeprops, xnode, gklist);
                        
                    } // foreach node


                    // Edges
                    var xedges = xgraph.Elements(ns + "edge").ToArray();

                    // Remove edges that doesn't exist anymore
                    for (int idx = xedges.Count() - 1; idx >= 0; idx--)
                    {
                        XElement xedge = xedges[idx];
                        var edg = Edges.Where(w => w.Id == NodeAttribute(xedge, "id")).FirstOrDefault();
                        if (edg == null)
                        {
                            xedge.Remove();

                        } // Not present

                    } // for
                    
                    foreach (WFEdge<WFNode> wfe in this.Edges)
                    {
                        XElement xedge = xedges.Where(w => NodeAttribute(w, "id") == wfe.Id).FirstOrDefault();
                        if (xedge == null)
                        {
                            xedge = new XElement(ns + "edge");
                            XAttribute xattr = new XAttribute("id", wfe.Id);
                            xedge.Add(xattr);

                            xgraph.Add(xedge);

                        } // Edge not in graphml

                        WFNode src = wfe.Source as WFNode;
                        WFNode trgt = wfe.Target as WFNode;

                        XAttribute attrsrc = xedge.Attribute("source");
                        if (attrsrc != null)
                        {
                            attrsrc.Value = src.Id;

                        }
                        else
                        {
                            attrsrc = new XAttribute("source", src.Id);
                            xedge.Add(attrsrc);

                        }
                        XAttribute attrtrgt = xedge.Attribute("target");
                        if (attrtrgt != null)
                        {
                            attrtrgt.Value = trgt.Id;

                        }
                        else
                        {
                            attrtrgt = new XAttribute("target", trgt.Id);
                            xedge.Add(attrtrgt);

                        }
                                                
                        Dictionary<string, string> edgeprops = GetPropertyValues(wfe);
                        MakeXelementsOfThese(edgeprops, xedge, gklist);
                        
                    } // foreach edge
                    
                    
                } // if xgraph not null

                // save here
                MemoryStream result = new MemoryStream();                
                xdoc.Save(result);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Stream SaveToGraphML()
        {
            try
            {
                XDocument xdoc = new XDocument();

                XNamespace ns = XNamespace.Get(GraphMLNameSpace);
                XElement xroot = new XElement(ns + "graphml");
                xdoc.Add(xroot);

                // Attributes
                foreach (GraphMLKey gk in graphmlkeys)
                {
                    XElement xkey = new XElement(ns + "key");
                    xkey.Add(new XAttribute(
                        "attr.name",
                        gk.Name
                        ));
                    xkey.Add(new XAttribute(
                        "attr.type",
                        gk.DataType
                        ));
                    xkey.Add(new XAttribute(
                        "for",
                        gk.ForType
                        ));
                    xkey.Add(new XAttribute(
                        "id",
                        gk.Id
                        ));

                    if (!string.IsNullOrWhiteSpace(gk.yFilesType))
                    {
                        xkey.Add(new XAttribute(
                        "yfiles.type",
                        gk.yFilesType
                        ));
                    } // Has yED stuff
                    
                    if (!string.IsNullOrWhiteSpace(gk.DefaultValue))
                    {
                        XElement xdefval = new XElement(ns + "default");
                        xdefval.Value = gk.DefaultValue;
                        xkey.Add(xdefval);
                        
                    } // Has default value
                    
                    xroot.Add(xkey);

                } // foreach attribute key

                XElement xgraph = new XElement(ns + "graph");
                xgraph.Add(new XAttribute(
                    "edgedefault",
                    "directed"
                    ));
                xgraph.Add(new XAttribute(
                    "id",
                    "G"
                    ));

                  xroot.Add(xgraph);

                // Graph properties
                Dictionary<string, string> graphprops = GetPropertyValues(this);
                MakeXelementsOfThese(graphprops, xgraph, graphmlkeys);


                // Nodes

                // Remove nodes that doesn't exist anymore
                foreach (WFNode wfn in this.Vertices)
                {
                    XElement xnode = new XElement(ns + "node");
                    XAttribute xattr = new XAttribute("id", wfn.Id);
                    xnode.Add(xattr);

                    xgraph.Add(xnode);

                    Dictionary<string, string> nodeprops = GetPropertyValues(wfn);
                    MakeXelementsOfThese(nodeprops, xnode, graphmlkeys);

                } // foreach node


                // Edges
                foreach (WFEdge<WFNode> wfe in this.Edges)
                {
                    XElement xedge = new XElement(ns + "edge");
                    XAttribute xattr = new XAttribute("id", wfe.Id);
                    xedge.Add(xattr);

                    xgraph.Add(xedge);

                    WFNode src = wfe.Source as WFNode;
                    WFNode trgt = wfe.Target as WFNode;

                    XAttribute attrsrc = xedge.Attribute("source");
                    if (attrsrc != null)
                    {
                        attrsrc.Value = src.Id;

                    }
                    else
                    {
                        attrsrc = new XAttribute("source", src.Id);
                        xedge.Add(attrsrc);

                    }
                    XAttribute attrtrgt = xedge.Attribute("target");
                    if (attrtrgt != null)
                    {
                        attrtrgt.Value = trgt.Id;

                    }
                    else
                    {
                        attrtrgt = new XAttribute("target", trgt.Id);
                        xedge.Add(attrtrgt);

                    }

                    Dictionary<string, string> edgeprops = GetPropertyValues(wfe);
                    MakeXelementsOfThese(edgeprops, xedge, graphmlkeys);

                } // foreach edge



                // save here
                MemoryStream result = new MemoryStream();
                xdoc.Save(result);

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

        public WFEdge<WFNode>[] GetEdgesFor(WFNode node)
        {
            WFEdge<WFNode>[] edgesfor = (
                from x in this.Edges
                where x.Source == node || x.Target == node
                select x
                ).ToArray();
                
            return edgesfor;
            

            //return this.OutEdges(node).ToArray();
        }

        public string[] GetUuids()
        {
            string[] uuids = (
                from x in Vertices
                where !string.IsNullOrEmpty(x.Uuid)
                select x.Uuid
                ).Distinct().ToArray();
            return uuids;
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

        public WFNode FindNode(string uuid, int major, int minor)
        {
            WFNode result = this.Vertices.Where(w =>
                w.Uuid.ToLower() == uuid.ToLower() &&
                w.Major == major &&
                w.Minor == minor
                ).FirstOrDefault();

            return result;

        }

        public WFNode FindNode(CacheNodeBeacon cnb)
        {
            if (cnb == null)
            {
                return null;

            } // cnb is null

            return FindNode(
                cnb.Uuid,
                cnb.Major,
                cnb.Minor
                );

        }
        
    } // class WFGraph


    public class GraphMLKey
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string ForType { get; set; }
        public string yFilesType { get; set; }
        public string DefaultValue { get; set; }


    } // GraphMLKey

}
