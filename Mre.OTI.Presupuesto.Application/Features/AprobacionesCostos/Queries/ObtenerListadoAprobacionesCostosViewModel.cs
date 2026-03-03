using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{
    public class ObtenerListadoAprobacionesCostosViewModel : IRequest<IEnumerable<ObtenerListadoAprobacionesCostosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
