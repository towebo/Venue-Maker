using KWENDA.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWENDA.Helpers
{
    public static class KWENDAFileItemHelper
    {
        public static void SaveFileTo(this KWENDAFileItem item, string folder, string newFileName = null)
        {
            if (item == null)
            {
                return;
            } // Is null

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);

            } // Missing

            string destfile = string.IsNullOrWhiteSpace(newFileName) ?
                item.FileName :
                newFileName;
            string fn = Path.Combine(
                folder,
                destfile
                );

            if (File.Exists(fn))
            {
                File.Delete(fn);

            } // Exists

            File.WriteAllBytes(fn, item.Data);

            if (item.LastModified.HasValue)
            {
                FileInfo fi = new FileInfo(fn);
                fi.LastWriteTimeUtc = item.LastModified.Value.ToUniversalTime();

            } // Set the file date



        }

    } // class

}