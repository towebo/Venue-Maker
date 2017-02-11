﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WayfindR.Models;
using SQLite;

namespace WayfindR.Controllers
{
    public class VenueController
    {
        private static VenueController me;

        private List<WFVenue> venues;


        public VenueController()
        {
            venues = new List<WFVenue>();

        }



        public void AddFromFolder(string folder, bool clearCache)
        {
            try
            {
                if (clearCache)
                {
                    SQLiteConnection db = SQLiteController.Me.Db;
                    db.DeleteAll<CacheFile>();

                } // clearCache

                string[] files = Directory.GetFiles(
                    folder,
                    "*.json"
                    );

                foreach (string fname in files)
                {
                    Add(fname);

                } // foreach
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("VenueController.AddFromFolder({0}): {1}",
                    folder,
                    ex.Message
                    ));

            }
        }
        

        public WFVenue Add(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    WFVenue v = WFVenue.FromJson(
                        File.ReadAllText(fileName)
                        );
                    if (v != null)
                    {
                        SQLiteConnection db = SQLiteController.Me.Db;

                        var rec = db.Table<CacheFile>().Where(w => w.FileName == fileName).FirstOrDefault();
                        if (rec == null)
                        {
                            CacheFile cif = new CacheFile();
                            cif.FileId = v.Id;
                            cif.FileName = fileName;
                            cif.FileExt = Path.GetExtension(fileName);

                            db.Insert(cif);

                        } // rec not found

                        return Add(v);

                    } // not null

                } // File Exists

                return null;

            }
            catch
            {
                return null;

            }

        }

        public WFVenue Add(WFVenue vnu)
        {
            try
            {
                venues.Add(vnu);
                return vnu;

            }
            catch
            {
                return null;

            }

        }


        public WFVenue[] Venues
        {
            get
            {
                return venues.ToArray();

            }
            set
            {
                venues = value.ToList();

            }

        } // Venues
        public WFVenue Current { get; set; }


        public static VenueController Me
        {
            get
            {
                if (me == null)
                {
                    me = new VenueController();

                }

                return me;

            } // get
        } // Me




    }
}
