using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerListadoTipodeCambioViewModel : IRequest<IEnumerable<ObtenerListadoTipoDeCambioResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
