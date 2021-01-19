using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MAWINGU.Authentication.DTO
{
    public class AuthenticateRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }


    }
}
