using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class UpdateKWENDAFilesRequest
    {
        [JsonProperty("inactivateAllForVenue")]
        public bool InactivateAllForVenue { get; set; }

        [JsonProperty("files")]
        public KWENDAFileItem[] Files { get; set; }




    } // class

}