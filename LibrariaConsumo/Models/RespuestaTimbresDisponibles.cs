using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo.Models
{
    public class RespuestaTimbresDisponibles
    {
        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
