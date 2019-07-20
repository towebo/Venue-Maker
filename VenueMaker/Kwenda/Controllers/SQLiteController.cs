using WayfindR.Models;
using SQLite;
using Kwenda;

namespace WayfindR.Controllers
{
    public class SQLiteController
    {
        private static SQLiteController me;
        private SQLiteConnection db;


        public SQLiteController()
        {
			db = new SQLiteConnection (
				DataController.GetAppFile (AppFile.SQLiteDb)
			);

            db.CreateTable<CacheFile>();
            db.CreateTable<CacheNodeBeacon>();

        }





        public static SQLiteController Me
        {
            get
            {
				if (me == null)
                {
                    me = new SQLiteController();
                }
                return me;
            }
        }

        public SQLiteConnection Db
        {
            get
            {
                return db;
            }
        }


    }
}
