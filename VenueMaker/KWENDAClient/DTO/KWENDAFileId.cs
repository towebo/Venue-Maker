using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class KWENDAFileId
    {
        [JsonProperty("venueId")]
        public string VenueId { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }




    } // class

}