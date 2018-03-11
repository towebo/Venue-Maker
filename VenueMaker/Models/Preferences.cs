using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VenueMaker.Helpers;

namespace VenueMaker.Models
{
    public class Preferences
    {
        private static Preferences me;


        public string DataFolder { get; set; }
        

        public static Preferences Me
        {
            get
            {
                if (me == null)
                {
                    me = new Preferences();

                } // Is null
                return me;

            } // get

        } // Preferences


        public static string PrefsFileName
        {
            get
            {
                //tmp string prefsfn = Path.Combine(folder, Constants.AppPrefsFileName);
                string prefsfn = Path.ChangeExtension(AssemblyInfo.ExeName, Constants.ConfigExtention);
                if (File.Exists(prefsfn))
                {
                    return prefsfn;

                } // Found

                string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                folder = Path.Combine(folder, Constants.CompanyFolderName);
                folder = Path.Combine(folder, Constants.ApplicationFolderName);

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);

                } // Doesn't exist

                return Path.Combine(folder, Constants.AppPrefsFileName);
            }
        }


        public Preferences()
        {
            SetDefaultValues();

        }


        public void SetDefaultValues()
        {
            if (string.IsNullOrWhiteSpace(DataFolder))
            {
                DataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Constants.ApplicationFolderName
                    );
            } // DataFolder

        }

        public static Preferences Load()
        {
            try
            {
                string filename = PrefsFileName;

                if (!File.Exists(filename))
                {
                    return Me;
                    //tmp throw new Exception("Filen finns inte.");

                } // Not found

                XmlSerializer deserializer = new XmlSerializer(typeof(Preferences));
                using (TextReader textReader = new StreamReader(filename))
                {
                    try
                    {
                        me = (Preferences)deserializer.Deserialize(textReader);

                    }
                    finally
                    {
                        textReader.Close();

                    }

                } // using

                me.SetDefaultValues();

                return me;

            }
            catch (Exception ex)
            {
                //tmp LogCenter.Error("Preferences.Load", ex.Message);
                throw;

            }
        }

        public void Save(string fileName = "")
        {
            try
            {
                string fn = !string.IsNullOrWhiteSpace(fileName) ?
                    fileName :
                    PrefsFileName;

                XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
                TextWriter textWriter = new StreamWriter(fn);

                serializer.Serialize(textWriter, this);

            }
            catch (Exception ex)
            {
                //tmp LogCenter.Error("Preferences.Save", ex.Message);
                throw;

            }

        }




    }
}
