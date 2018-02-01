using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Models
{
    public class CreateAccountInfoModel
    {
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }

    }
}
