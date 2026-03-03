using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Queries
{
    public class ObtenerListadoCmnViewModel : IRequest<IEnumerable<ObtenerListadoCmnResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}