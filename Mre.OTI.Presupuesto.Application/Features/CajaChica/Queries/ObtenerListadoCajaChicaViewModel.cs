using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerListadoCajaChicaViewModel : IRequest<IEnumerable<ObtenerListadoCajaChicaResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public string usuarioConsulta { get; set; }
    }
}