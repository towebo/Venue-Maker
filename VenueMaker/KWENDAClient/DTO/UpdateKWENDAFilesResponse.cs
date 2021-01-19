using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class UpdateKWENDAFilesResponse
    {
        [JsonProperty("error")]
        public WebAPIError Error { get; set; }


    } // class

}