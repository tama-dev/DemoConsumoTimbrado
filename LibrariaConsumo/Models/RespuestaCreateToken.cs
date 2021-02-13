using Newtonsoft.Json;
using System;


namespace LibrariaConsumo.Models
{
    public class RespuestaCreateToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}
