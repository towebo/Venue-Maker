using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using VenueMaker.Controllers;

namespace WayfindR.Models
{
    public class RoutePreferences
    {
        private static RoutePreferences routeprefs;

        public bool Elevators { get; set; }
        public bool Escalators { get; set; }
        public bool Stairs { get; set; }
        public bool MetalStairs { get; set; }
        public bool Ladders { get; set; }
        

        public static RoutePreferences Me
        {
            get
            {
                if (routeprefs == null)
                {
                    routeprefs = new RoutePreferences();
                }
                return routeprefs;
            } // get

        } // Me


        public RoutePreferences()
        {
            Elevators = true;
            Escalators = true;
            Stairs = true;
            MetalStairs = true;

        }


        public static RoutePreferences Load()
        {
            RoutePreferences storedprefs;
            try
            {
                string filename = "";// DataController.GetAppFile(AppFile.RoutePrefs);

                if (File.Exists(filename))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(RoutePreferences));
                    using (TextReader textReader = new StreamReader(filename))
                    {
                        try
                        {
                            storedprefs = (RoutePreferences)deserializer.Deserialize(textReader);

                        }
                        finally
                        {
                            textReader.Close();

                        }

                    } // using

                }
                else
                {
                    storedprefs = new RoutePreferences();
                }

                routeprefs = storedprefs;

                return routeprefs;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Me;

            }

        }


        public static RoutePreferences Save()
        {
            try
            {
                RoutePreferences myprefs = Me;

                string filename = ""; //tmp DataController.GetAppFile(AppFile.RoutePrefs);
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                {
                    fi.Delete();
                } // Exists

                XmlSerializer serializer = new XmlSerializer(typeof(RoutePreferences));
                TextWriter textWriter = new StreamWriter(filename);

                serializer.Serialize(textWriter, myprefs);
                return myprefs;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Me;

            }

        }



    }
}
