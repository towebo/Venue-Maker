using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Controllers
{
    public class DataController
    {
        private static DataController me;



        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }



        public static DataController Me
        {
            get
            {
                if (me == null)
                {
                    me = new DataController();

                } // Is null
                return me;
            } // get
        } // Me


    }
}
