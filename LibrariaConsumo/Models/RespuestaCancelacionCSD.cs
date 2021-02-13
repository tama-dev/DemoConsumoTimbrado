using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo.Models
{
    public class RespuestaCancelacionCSD
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("acuseCancelacion")]
        public string AcuseCancelacion { get; set; }
    }
}
