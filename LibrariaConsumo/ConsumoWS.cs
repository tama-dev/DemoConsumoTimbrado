using LibrariaConsumo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo
{
    public class ConsumoWS : IConsumoWS
    {
        private const string URL_SERVICE = "https://timbrados.tamagas.com";
        public RespuestaCreateToken ObtieneToken(string usuario, string password)
        {

            CreateTokenCredenciales credenciales = new CreateTokenCredenciales
            {
                Username = usuario,
                Password = password
            };

            string credencialesJson = JsonConvert.SerializeObject(credenciales);


            var client = new RestClient($"{URL_SERVICE}/Account/CreateToken");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "ARRAffinity=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669; ARRAffinitySameSite=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669");
            request.AddParameter("application/json", credencialesJson, ParameterType.RequestBody);
            
            //usar esta línea de código si el framework es menor a 4.7.2, esto es por el https 
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            IRestResponse response = client.Execute(request);

            //serializamos

            //con puro restSharp seria así :
            //JsonDeserializer deserial = new JsonDeserializer();
            //return deserial.Deserialize<RespuestaCreateToken>(response);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception("Claves de PAC incorrectas");

            RespuestaCreateToken resp = JsonConvert.DeserializeObject<RespuestaCreateToken>(response.Content);
            return resp;

        }

        public RespuestaFacturacion Timbrar(string token, string xmlString)
        {

            TimbradoXmlData xmlATimbrar = new TimbradoXmlData() {
                Xml = xmlString
            };
            string xmlSerializado = JsonConvert.SerializeObject(xmlATimbrar);

            var client = new RestClient($"{URL_SERVICE}/Api/FacturasAPI/FacturarXml");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "ARRAffinity=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669; ARRAffinitySameSite=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669");
            request.AddParameter("application/json", xmlSerializado, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            RespuestaFacturacion resp = JsonConvert.DeserializeObject<RespuestaFacturacion>(response.Content);

            if (!string.IsNullOrEmpty(resp.Error))
                throw new Exception(resp.Error);

            return resp;

        }

        public long TimbresDisponibles(string token)
        {
            var client = new RestClient($"{URL_SERVICE}/Api/FacturasAPI/TimbresDisponibles");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {token}");
            //request.AddHeader("Cookie", "ARRAffinity=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669; ARRAffinitySameSite=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669");
            IRestResponse response = client.Execute(request);

            RespuestaTimbresDisponibles resp = JsonConvert.DeserializeObject<RespuestaTimbresDisponibles>(response.Content);

            if (!string.IsNullOrEmpty(resp.Error))
                throw new Exception(resp.Error);

            return resp.Cantidad;
        }

        /// <summary>
        /// Cancela con los certificados en base64
        /// </summary>
        /// <param name="token"></param>
        /// <param name="datosCancel"></param>
        /// <returns>Regresa el acuse de cancelación </returns>
        public string Cancela(string token, CancelacionDataCSD datosCancel)
        {
            string datosCancelSerializados = JsonConvert.SerializeObject(datosCancel);
            var client = new RestClient($"{URL_SERVICE}/Api/FacturasAPI/CancelarCSD");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "ARRAffinity=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669; ARRAffinitySameSite=a4d7bddfba22dd5d8ac277b5ebbb4370b7b1f9719b58675583154d70fedac669");
            request.AddParameter("application/json", datosCancelSerializados, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            RespuestaCancelacionCSD resp = JsonConvert.DeserializeObject<RespuestaCancelacionCSD>(response.Content);

            if (!string.IsNullOrEmpty(resp.Error))
                throw new Exception(resp.Error);

            return resp.AcuseCancelacion;
        }


        
        
    }
}
