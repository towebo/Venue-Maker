using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Helpers
{
    public static class PasswordHelper
    {

        public static string Encrypt(this string plain)
        {

            byte[] data = Encoding.UTF8.GetBytes(plain);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = Encoding.UTF8.GetString(data);
            
            return hash;

        }



    }
}
