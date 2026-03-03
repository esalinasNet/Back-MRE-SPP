using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerProyectoPaginadoViewModel : IRequest<dtProyectoPaginadoResponseViewModel>
    {        
        public int? anio { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idActividadOperativa { get; set; }
        public int? tipoUbigeo { get; set; }

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}