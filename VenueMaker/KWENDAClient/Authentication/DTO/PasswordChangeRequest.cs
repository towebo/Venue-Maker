using Newtonsoft.Json;

namespace MAWINGU.Authentication.DTO
{
    public class PasswordChangeRequest
    {
        [JsonProperty("eMail")]
        public string Email { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}
