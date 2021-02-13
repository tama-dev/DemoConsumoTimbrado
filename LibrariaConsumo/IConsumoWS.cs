using LibrariaConsumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariaConsumo
{
    public interface IConsumoWS
    {
        RespuestaCreateToken ObtieneToken(string usuario, string password);
        RespuestaFacturacion Timbrar(string token, string xmlString);
        long TimbresDisponibles(string token);
        string Cancela(string token, CancelacionDataCSD datosCancel);

    }
}
