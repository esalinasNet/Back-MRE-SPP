using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Rol;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerRolPaginadoViewModel : IRequest<dtRolPaginadoResponseViewModel>
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string usuarioConsulta { get; set; }
        public int draw { get; set; }

        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
