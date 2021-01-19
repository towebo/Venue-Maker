using Newtonsoft.Json;
using System.Net;

namespace KWENDA.DTO
{
    public class WebAPIError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }


        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }


        public WebAPIError()
            : this(0, "", HttpStatusCode.OK)
        {
        }


        public WebAPIError(int code, string msg, HttpStatusCode status)
        {
            Code = code;
            Message = msg;
            Status = status;

        }


    }
}
