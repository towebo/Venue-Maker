using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenueMaker.Models
{

    public class DataFile
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "venueid")]
        public string VenueId { get; set; }

        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "fileext")]
        public string FileExt { get; set; }

        [JsonProperty(PropertyName = "lastmodified")]
        public DateTime LastModified { get; set; }

        [JsonProperty(PropertyName = "filesize")]
        public long FileSize { get; set; }



    }
}