﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WayfindR.Models;


namespace WayfindR.Controllers
{
    public class GraphController
    {
        private static GraphController me;
        private List<WFGraph> graphs;


        public GraphController()
        {
            graphs = new List<WFGraph>();

        }


        public void AddFromFolder(string folder)
        {
            try
            {
                string[] files = Directory.GetFiles(
                    folder,
                    "*.graphml"
                    );

                foreach (string fname in files)
                {
                    Add(fname);

                } // foreach

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GraphController.AddFromFolder({0}): {1}",
                    folder,
                    ex.Message
                    ));

            }
        }


        public WFGraph Add(string fileName)
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

                        if (grph != null)
                        {
                            return Add(grph);

                        } // not null

                    } // using
                        
                    
                    
                } // File Exists

                return null;

            }
            catch
            {
                return null;


            }
        }

        public WFGraph Add(WFGraph grph)
        {
            try
            {
                graphs.Add(grph);
                return grph;

            }
            catch
            {
                return null;

            }

        }


        public void BuildNodeCache()
        {
            try
            {
                SQLiteConnection db = SQLiteController.Me.Db;
                db.CreateTable<WFNodeBeacon>();
                db.DeleteAll<WFNodeBeacon>();
                
                foreach (WFGraph g in Graphs)
                {
                    foreach (WFNode n in g.Vertices)
                    {
                        WFNodeBeacon nb = new WFNodeBeacon();
                        nb.Major = n.Major;
                        nb.Minor = n.Minor;
                        //nb.Distance = n.Accuracy;

                        nb.GraphId = g.Id;
                        nb.VenueId = g.VenueId;

                        db.Insert(nb);

                    } // foreach node

                } // foreach graph

            }
            catch
            {
                throw;

            }

        }

        public WFGraph[] RelatedToVenue(string venueId)
        {
            try
            {
                WFGraph[] result = (
                    from x in this.Graphs.ToList()
                    where x.VenueId == venueId
                    select x
                    ).ToArray();

                return result;

            }
            catch
            {
                return null;

            }

        }


        // Properties
        public WFGraph[] Graphs
        {
            get
            {
                return graphs.ToArray();
            }
            set
            {
                graphs = value.ToList();
            }
        }


        public static GraphController Me
        {
            get
            {
                if (me == null)
                {
                    me = new GraphController();

                }
                return me;

            } // get

        } // Me


    }
}
