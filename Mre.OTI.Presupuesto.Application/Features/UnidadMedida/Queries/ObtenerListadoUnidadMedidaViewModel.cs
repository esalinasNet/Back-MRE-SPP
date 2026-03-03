using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerListadoUnidadMedidaViewModel : IRequest<IEnumerable<ObtenerListadoUnidadMedidaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
