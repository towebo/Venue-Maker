using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class GetKWENDAFilesResponse
    {
        [JsonProperty("error")]
        public WebAPIError Error { get; set; }

        [JsonProperty("files")]
        public KWENDAFileItem[] Files { get; set; }


    } // class

}