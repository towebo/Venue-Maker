using Newtonsoft.Json;
using System;

namespace WayfindR.Models
{
    public class KwendaFile
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






    }
}
