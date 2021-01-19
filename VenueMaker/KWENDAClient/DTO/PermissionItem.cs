using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KWENDA.DTO
{
    public class PermissionItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("venueId")]
        public string VenueId { get; set; }

        [JsonProperty("grant_permission")]
        public bool GrantPermission { get; set; }

        [JsonProperty("readonly_access")]
        public bool ReadOnlyAccess { get; set; }


    } // class

}