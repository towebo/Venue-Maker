using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class SetKWENDAFilePermissionsRequest
    {
        [JsonProperty("items")]
        public PermissionItem[] Items { get; set; }

    } // class

}