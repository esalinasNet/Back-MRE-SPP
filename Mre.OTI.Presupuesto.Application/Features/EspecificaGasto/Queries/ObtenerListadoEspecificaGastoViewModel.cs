using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerListadoEspecificaGastoViewModel : IRequest<IEnumerable<ObtenerListadoEspecificaGastoResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
