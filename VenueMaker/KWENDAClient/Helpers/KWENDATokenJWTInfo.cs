using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWENDA.Helpers
{
    public class KWENDATokenJWTInfo
    {
        [JsonProperty("unique_name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("exp")]
        public long Expires_UnixTimeStamp { get; set; }


    } // class

}