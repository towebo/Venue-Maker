using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MAWINGU.Authentication.DTO
{
    public class ErrorResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        //[JsonProperty("errors")]
        //public StringArray Errors { get; set; }



        public ErrorResponse(int code, string msg)
        {
            Code = code;
            Message = msg;

        }

    } // class

    [JsonArray]
    public class StringArray
    {
        [JsonProperty]
        public string[] Errors { get; set; }

    }

}