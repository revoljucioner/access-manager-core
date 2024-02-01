using AccessManager.Models.Enum;
using Newtonsoft.Json;

namespace AccessManager.Models.Responses
{
    public class GetUserInfoResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role_id")]
        public UserRole Role { get; set; }
    }
}
