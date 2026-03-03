using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Viaticos;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries
{
    public class ObtenerListadoViaticosViewModel : IRequest<IEnumerable<ObtenerListadoViaticosResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}