using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo.Models
{
    public class RespuestaFacturacion
    {
        [JsonProperty("xml")]
        public string Xml { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("certificado")]
        public string Certificado { get; set; }
        [JsonProperty("noCertificado")]
        public string NoCertificado { get; set; }
        [JsonProperty("sello")]
        public string Sello { get; set; }
        [JsonProperty("cantidadLetra")]
        public string CantidadLetra { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("selloSAT")]
        public string SelloSAT { get; set; }
        [JsonProperty("fechaTimbrado")]
        public DateTime FechaTimbrado { get; set; }
        [JsonProperty("certificadoSAT")]
        public string CertificadoSAT { get; set; }
        [JsonProperty("versionTFD")]
        public string VersionTFD { get; set; }

        [JsonProperty("qrData")]
        public string QrData { get; set; }

        [JsonProperty("cadenaOriginalCertDig")]
        public string CadenaOriginalCertDig { get; set; }
    }
}
