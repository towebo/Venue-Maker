using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayfindR.Models
{
    public enum WFMapType
    {
        Jpg = 0,
        Png = 1
    } // Enum

    public class WFMap
    {
        private string _filename;

        public string Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string FileName
        {
            get { return _filename; }
            set
            {
                _filename = value;
                string ext = Path.GetExtension(_filename).ToLower();
                if (ext == "jpg" ||
                    ext == "jpeg")
                {
                    MapType = WFMapType.Jpg;

                }
                else if (ext == ".png")
                {
                    MapType = WFMapType.Png;

                } // else

            } // set
        } // FileName
        public WFMapType MapType { get; set; }

    } // class
}
