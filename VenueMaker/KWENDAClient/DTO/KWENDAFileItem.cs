using Newtonsoft.Json;
using System;

namespace KWENDA.DTO
{
    public class KWENDAFileItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("venueId")]
        public string VenueId{ get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileExt")]
        public string FileExt { get; set; }

        [JsonProperty("fileTitle")]
        public string FileTitle { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("data")]
        public byte[] Data { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }



    } // class

}