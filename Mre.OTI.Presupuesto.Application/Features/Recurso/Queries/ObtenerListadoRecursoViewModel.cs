using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Queries
{
    public class ObtenerListadoRecursoViewModel : IRequest<IEnumerable<ObtenerListadoRecursoResponseViewModel>>
    {
        public int? idProgramacionTareas { get; set; }
        public string usuarioConsulta { get; set; }
    }
}