using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerCajaChicaPaginadoViewModel : IRequest<dtCajaChicaPaginadoResponseViewModel>
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? anio { get; set; }
        public int? tipoUbigeo { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }
        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}