using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerListadoEncargosViewModel : IRequest<IEnumerable<ObtenerListadoEncargosResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}