using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using WayfindR.Models;

namespace VenueMaker.Controllers
{
    public class KwendaFileService
    {
        static KwendaFileService instance = new KwendaFileService();

        const string applicationURL = @"https://kwenda.azurewebsites.net";

        private MobileServiceClient client;
        private IMobileServiceTable<KwendaFile> filetable;

        private KwendaFileService()
        {
            //tmp CurrentPlatform.Init();

            // Initialize the client with the mobile app backend URL.
            client = new MobileServiceClient(applicationURL);

            filetable = client.GetTable<KwendaFile>();

        }

        public static KwendaFileService DefaultService
        {
            get
            {
                return instance;
            }
        }

        public List<KwendaFile> Files { get; private set; }

        public async Task<List<KwendaFile>> RefreshDataAsync()
        {
            try
            {                
                Files = await filetable.ToListAsync();

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                //return null;
                throw;
            }

            return Files;
        }

        public async Task InsertFileAsync(KwendaFile file)
        {
            try
            {
                await filetable.InsertAsync(file); // Insert a new TodoItem into the local database.

                Files.Add(file);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }

        public async Task UpdateFileAsync(KwendaFile file)
        {
            try
            {
                await filetable.UpdateAsync(file); // Update todo item in the local database

                //tmp Items.Remove(file);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }




    }
}
