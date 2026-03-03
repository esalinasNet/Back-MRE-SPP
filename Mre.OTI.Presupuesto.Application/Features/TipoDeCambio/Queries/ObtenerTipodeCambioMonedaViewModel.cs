using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerTipodeCambioMonedaViewModel : IRequest<IEnumerable<ObtenerTipoDeCambioMonedaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public string codigoIso { get; set; }          
        
    }
}
