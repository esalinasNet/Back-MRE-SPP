using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries
{
    public class ObtenerListadoOtrosGastosViewModel : IRequest<IEnumerable<ObtenerListadoOtrosGastosResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}