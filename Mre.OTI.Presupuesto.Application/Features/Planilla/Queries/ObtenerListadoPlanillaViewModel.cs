using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planilla;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Planilla.Queries
{
    public class ObtenerListadoPlanillaViewModel : IRequest<IEnumerable<ObtenerListadoPlanillaResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}