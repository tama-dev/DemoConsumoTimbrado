﻿using LibrariaConsumo;
using LibrariaConsumo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumidorDLL
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("obtenemos token");

            //consumimos la libreria 
            IConsumoWS consumoDemo = new ConsumoWS();
            //obtenemos el token, que es con el que vamos a consumir todos nuestros métodos.
            //el token vence cada 2 horas, dentro de ese lapso preferentemente usar el mismo token.
            RespuestaCreateToken respuestaToken =  consumoDemo.ObtieneToken("", "");
            string token = respuestaToken.Token;

            Console.WriteLine("vemos los timbres disponibles");

            long timbresDisponibles = consumoDemo.TimbresDisponibles(token);


            Console.WriteLine("Cancelamos");

            CancelacionDataCSD canc = new CancelacionDataCSD
            {
                Uuid = "bff47862-27b4-4583-bd1e-ca9b940ba8f4",
                Clave = "12345678a",
                Rfc = "AAA010101AAA",
                B64Cer = Convert.ToBase64String(File.ReadAllBytes(@"C:\demo\certificado.cer")), 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
                B64Key = Convert.ToBase64String(File.ReadAllBytes(@"C:\demo\llave.key")) //MIIFDjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQIAgEAAoIBAQACAggAMBQGCCqGSIb3DQMHBAgwggS+AgEAMASCBMh4EHl7aNSCaMDA1VlRoXCZ5UUmqErAbuck7ujDnmKxSaOGzJzn1hAlfBWJNtr1rgiCXRHB5/2qJ/CnTOkCcgutvs1xl3vxHgY1+N9I60iZUG+yjfEd+ungL4alXXMtKgZ8CkQXaeYIeQXFdyZ5jUU07Cy+LjMrIOAh1m/VnL6U/qW3dY+oJmII6gCG0SKcfCojeCpBVL2ispK2CBTpMDO4hd7vnbFhafl9/wUkAncmz5SHLjXPMKgmK7HvBiUSMRYFCjcNEBvMshI7E1//nG8pi0Xrmbq4MfT1B+SF8vbA39hCqKP32m+QFlOduHlaFSnW96UkMBT5hF1qImwU3HTbtKfAumo3BLzYJ9XP7Y6eVOFFSSsXudrAt94mH7CojUjazGHBsqagsUY85Q7Cz0TTvnnvWFNFAj/xbQm6nT1VL8FkdJm8hEb5YLaOqQZ8y1AEv8sCq/M51aHglexuzGFIIUTF+/XQGeYDBITlS6z2TryoHp8n1+6LpClL51WrIfaSxyMEtG2fmAHN82iNujOP6MBR7aMZ6dfxJctFRAaWlmi89wa5VhyeaoDzkx1roJznF3MLxVKROmYLDYk142IwRtTgWrex4Wnidpo4unrfL+uj6VwTUDk0cizaYvamRhlZ/LXdwyB1syb/GQGu94gSzB1zAzb5/IIbtyofK+/tVTv08OMpCqHfBye1QJQg+vxQHMkbhZH6sEgORSEjuidW13DTKi8xyryQsD5WccMh8WDxMuAVFUldrwWdGilFKg0G99S/XJWLwKB74Nv0v/Ygdp6/d9T0fFD3FXpb9RznErCgfVSMtrPv1svGg3QFwh+qmkzjh+NBwUrmmqEjNshji+9SB4fnJNYlKVvu4WAzMKliixUkRcCID1QYwLtiyWuwZDYxKTnk7Y1LXmRGqqhNbh4kdnTNUdkxEjqp+UVtBdaxswa6s4qrLbNeD7VN+1KJEMN6/zZ6+2Uj2KBMzaDA0zwAHMB1gyPkgX0v47e61iffaVAUQzDGYGbDERG2vT8234NSDdgqzOpsf7il2Pv+uF0oab+db62JiRvOEjNefXG5p8KRudYyaVO8N7iTdRRj/A/yDwjmSq9dDCZEZE0cD6BEaAgmjvqwF5IvGgJGnWYKhrOGBPv+VL6zGOXo/L9zenxYwKNTHzNYlvug/t4gXQmArroqA2YKBGpYb8/FY/q3t3k+u1bXWvNLOzWi81InvxFSCTu6l9GBCthyWwekWdoL6ssSzOmzPr/d2klSRST3ByJmAJzLGJFsj6AL01BaUVWERH0s+GmnSWOU8ZIQVGF7aOEWWbtD0vyjJRxQnxPxn+Tt3oT9Nob10QGwG/2tNZtZuhAMf1yt+cF8jl0hC/LI0FtMqmLAkxaEOiXHmFuKXbAjFxIjdIwgWsAZe1cTLzR44jIKwlB64jvh1LXmJ5jCszLd/fuCEB0XZUWLDRCZVb82MqcZl7U/gaFazSqm71NNafCDzWjWO4ukWN1lcTDJE05KgeRqoYIEcpU8jXy/CAEaoseA1bWDnfnLJk2axVXzmrtYnojyKjTjDz3In41Kjsx3nNOegqtH7O2gl9YBzJfgwZmF0ldk+udcotc0JwIXYWk7b5HmRgXWa+WvDHSwyLzMrbw=
            };


            consumoDemo.Cancela(token, canc);


            Console.WriteLine("Timbramos");
            string xmlutf8 = Encoding.UTF8.GetString(File.ReadAllBytes(@"C:\demo\pre_xml.xml") );
            RespuestaFacturacion respuestaFactu = consumoDemo.Timbrar(token, xmlutf8);



            Console.ReadLine();
        }
    }
}
