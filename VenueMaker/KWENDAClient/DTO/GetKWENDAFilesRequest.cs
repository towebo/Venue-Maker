using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class GetKWENDAFilesRequest
    {
        [JsonProperty("fileIds")]
        public KWENDAFileId[] FileIds { get; set; }

        [JsonProperty("includeData")]
        public bool IncludeData{ get; set; }



    } // class
}