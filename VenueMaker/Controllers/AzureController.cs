using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VenueMaker.Models;

namespace VenueMaker.Controllers
{
    public class AzureController
    {

        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://kwenda.azurewebsites.net"
        );


        public async static void Populate()
        {
            DataFile df = new DataFile();
            df.FileName = "Towebo.graphml";
            df.VenueId = "0431453084";
            df.FileExt = "graphml";

            df.LastModified = DateTime.Now;
            df.FileSize = 1024;

            await MobileService.GetTable<DataFile>().InsertAsync(df);

        }

        public async static void haveALook()
        {
            IMobileServiceTable<DataFile> filesTable = MobileService.GetTable<DataFile>();
            var items = await filesTable.ToListAsync();
            foreach (DataFile df in items)
            {
                string fn = df.FileName;
                if (string.IsNullOrWhiteSpace(fn))
                {
                    fn = "Harry";
                }
            }


        }





    }

}
