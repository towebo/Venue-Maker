using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Kwenda;

namespace WayfindR.Models
{
    public class POIInfoCategoryPreferences
    {
        private static POIInfoCategoryPreferences infocatprefs;

        public bool InteriorDescriptions { get; set; }
        public bool Offers { get; set; }
        public bool DescriptiveImages { get; set; }
        
        


        public static POIInfoCategoryPreferences Me
        {
            get
            {
                if (infocatprefs == null)
                {
                    infocatprefs = new POIInfoCategoryPreferences();
                }
                return infocatprefs;
            } // get

        } // Me


        public POIInfoCategoryPreferences()
        {
            InteriorDescriptions = true;
            Offers = true;
            DescriptiveImages = true;
            
        }


        public bool ShouldDisplay(WFInfoCategory infocat)
        {
            bool result = true;

            if (!InteriorDescriptions &&
                infocat == WFInfoCategory.Interior)
            {
                result = false;

            }
            else if (!DescriptiveImages &&
                     infocat == WFInfoCategory.DescriptiveImage)
            {
                result = false;

            }
            else if (!Offers &&
                     infocat == WFInfoCategory.Offer)
            {
                result = false;

            }

            return result;

        }



        public static POIInfoCategoryPreferences Load()
        {
            POIInfoCategoryPreferences storedprefs;
            try
            {
                string filename = DataController.GetAppFile(AppFile.InfoCatPrefs);

                if (File.Exists(filename))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(POIInfoCategoryPreferences));
                    using (TextReader textReader = new StreamReader(filename))
                    {
                        try
                        {
                            storedprefs = (POIInfoCategoryPreferences)deserializer.Deserialize(textReader);

                        }
                        finally
                        {
                            textReader.Close();

                        }

                    } // using

                }
                else
                {
                    storedprefs = new POIInfoCategoryPreferences();
                }

                infocatprefs = storedprefs;

                return infocatprefs;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Me;

            }

        }


        public static POIInfoCategoryPreferences Save()
        {
            try
            {
                POIInfoCategoryPreferences myprefs = Me;

                string filename = DataController.GetAppFile(AppFile.InfoCatPrefs);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                } // Exists

                XmlSerializer serializer = new XmlSerializer(typeof(POIInfoCategoryPreferences));
                using (TextWriter textWriter = new StreamWriter(filename))
                {
                    try
                    {
                        serializer.Serialize(textWriter, myprefs);
                        return myprefs;

                    }
                    finally
                    {
                        textWriter.Close();


                    }
                } // using

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Me;

            }

        }



    }

}
