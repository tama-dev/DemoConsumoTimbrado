using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo.Models
{
    public class TimbradoXmlData
    {
        [JsonProperty("xml")]
        public string Xml { get; set; }
    }
}
