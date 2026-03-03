using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.FasesPoi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Queries
{
    public class ObtenerListadoFasesPoiViewModel : IRequest<IEnumerable<ObtenerListadoFasesPoiResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
