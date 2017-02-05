using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WayfindR.Models;

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



        public void AddFromFolder(string folder)
        {
            try
            {
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
