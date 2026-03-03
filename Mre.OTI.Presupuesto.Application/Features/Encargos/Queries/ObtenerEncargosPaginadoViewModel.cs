using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerEncargosPaginadoViewModel : IRequest<dtEncargosPaginadoResponseViewModel>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? anio { get; set; }
        public int? tipoUbigeo { get; set; }
        public string denominacionRecurso { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }
        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}