using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class SignInRequest
    {
        [JsonProperty("eMail")]
        public string Email { get; set; }

        [JsonProperty("client")]
        public string Client { get; set; }


    }
}
