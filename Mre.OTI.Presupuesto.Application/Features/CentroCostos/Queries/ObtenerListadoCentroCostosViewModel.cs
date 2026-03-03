using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries
{
    public class ObtenerListadoCentroCostosViewModel : IRequest<IEnumerable<ObtenerListadoCentroCostosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
