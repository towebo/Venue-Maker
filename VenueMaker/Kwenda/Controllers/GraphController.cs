using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WayfindR.Models;
using SQLite;
using Kwenda;
using Mawingu;
using MAWINGU.Logging;

namespace WayfindR.Controllers
{
    public class GraphController
    {
        private static GraphController me;
        private List<WFGraph> graphs;

        public const string GraphMLFileExt = ".graphml";


        public GraphController()
        {
            graphs = new List<WFGraph>();

        }

        
        public void AddFromVenues(WFVenue[] venues, bool clearCache)
        {
            try
            {
                this.graphs.Clear();

                if (clearCache)
                {
                    SQLiteConnection db = SQLiteController.Me.Db;
                    db.DeleteAll<CacheFile>();

                } // clearCahce
                

                foreach (WFVenue v in venues)
                {
                    if (v.NodesGraph != null)
                    {
                        Add(v.NodesGraph);

                    } // Not null
                    else
                    {
                        LogCenter.Error("AddFromVenues", v.Name);
                    }

                } // foreach

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GraphController.AddFromVenues(): {0}",
                    ex.Message
                    ));

            }
        }

        public void AddFromFolder(string folder, bool clearCache)
        {
            try
            {
                this.graphs.Clear();

                if (clearCache)
                {
                    SQLiteConnection db = SQLiteController.Me.Db;
                    db.DeleteAll<CacheFile>();

                } // clearCahce

                string[] files = Directory.GetFiles(
                    folder,
                    "*" + GraphMLFileExt
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
                            SQLiteConnection db = SQLiteController.Me.Db;

                            var rec = db.Table<CacheFile>().Where(w => w.FileName == fileName).FirstOrDefault();
                            if (rec == null)
                            {
                                CacheFile cif = new CacheFile();
                                cif.GraphId = grph.GraphId;
                                cif.VenueId = grph.VenueId;
                                cif.FileName = fileName;
                                cif.FileExt = Path.GetExtension(fileName);

                                db.Insert(cif);
                            
                            } // rec not found

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
                db.DeleteAll<CacheNodeBeacon>();
                
                foreach (WFGraph g in Graphs)
                {
                    if (g.Vertices == null)
                    {
                        continue;

                    }
                    foreach (WFNode n in g.Vertices)
                    {
                        CacheNodeBeacon nb = new CacheNodeBeacon();
						nb.Uuid = n.Uuid == null ? string.Empty : n.Uuid.ToLower();
                        nb.Major = n.Major;
                        nb.Minor = n.Minor;
                        //nb.Distance = n.Accuracy;

                        nb.GraphId = g.GraphId;
                        nb.VenueId = g.VenueId;
                        nb.NodeName = n.Name;
                        nb.WaypointType = n.WaypointType;

                        WFVenue v = VenueController.Me.FindVenue(n.VenueId);
                        if (v != null)
                        {
                            nb.VenueName = v.Name;

                        } // Found the venue

                        db.Insert(nb);

                    } // foreach node

                } // foreach graph

            }
            catch (Exception ex)
            {
                LogCenter.Error("BuildNodeCache", ex.Message);
                throw;

            }

        }

        public void ClearGraphs()
        {
            this.graphs.Clear();

        }

		public void ClearLocalData(string folder)
		{
			try
			{
				string[] files = Directory.GetFiles(
					folder,
					"*" + GraphMLFileExt
					);

				foreach (string fname in files)
				{
					File.Delete(fname);

				} // foreach

			}
			catch (Exception ex)
			{
				LogCenter.Error("GraphController.ClearLocalData()", ex.Message);


			}

		}

        public WFGraph FindGraph(string graphId)
        {
            if (string.IsNullOrEmpty(graphId))
            {
                return null;

            } // no id

            WFGraph result = graphs.Where(w => w.GraphId == graphId).FirstOrDefault();
            if (result == null)
            {
                var rec = SQLiteController.Me.Db.Table<CacheFile>()
                    .Where(w => w.GraphId == graphId && w.FileExt == GraphMLFileExt)
                    .FirstOrDefault();
                if (rec != null)
                {
                    result = Add(rec.FileName);

                } // if not null                

            } // graph not in memory


            return result;

        }
        
        public WFGraph[] RelatedToVenue(string venueId)
        {
            try
            {
                List<WFGraph> result = new List<WFGraph>();

                // Look in cache
                var recs = SQLiteController.Me.Db.Table<CacheFile>()
                    .Where(w => w.VenueId == venueId && w.FileExt == GraphMLFileExt);

                foreach (CacheFile cf in recs)
                {
                    result.Add(
                        Add(cf.FileName)
                        );

                } // foreach

                return result.ToArray();

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
