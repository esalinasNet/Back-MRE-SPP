using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerListadoProyectoViewModel : IRequest<IEnumerable<ObtenerListadoProyectoResponseViewModel>>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public int? idActividadOperativa { get; set; }
        public string usuarioConsulta { get; set; }
    }
}