using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWENDA.DTO
{
    public class ListKWENDAFilesRequest
    {
        [JsonProperty("newerThan")]
        public DateTime? NewerThan { get; set; }


    } // class

}