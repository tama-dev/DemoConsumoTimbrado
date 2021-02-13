using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo.Models
{
    public class CancelacionDataCSD
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("rfc")]
        public string Rfc { get; set; }

        [JsonProperty("clave")]
        public string Clave { get; set; }

        [JsonProperty("b64Cer")]
        public string B64Cer { get; set; }

        [JsonProperty("b64Key")]
        public string B64Key { get; set; }
    }
}
