using Newtonsoft.Json;

namespace LibrariaConsumo.Models
{
    public class CreateTokenCredenciales
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
