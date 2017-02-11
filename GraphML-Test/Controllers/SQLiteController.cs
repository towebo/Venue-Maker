using SQLite;
using WayfindR.Models;

namespace WayfindR.Controllers
{
    public class SQLiteController
    {
        private static SQLiteController me;
        private SQLiteConnection db;


        public SQLiteController()
        {
            db = new SQLiteConnection(
                @"C:\Users\karl-otto\Dropbox\src\Wayfindr\graphmltest\Data\Data.db3"
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
