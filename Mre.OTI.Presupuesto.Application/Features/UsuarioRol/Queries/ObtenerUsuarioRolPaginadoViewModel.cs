using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UsuarioRol;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries
{
    public class ObtenerUsuarioRolPaginadoViewModel : IRequest<dtUsuarioRolPaginadoResponseViewModel>
    {
        public int idSistema { get; set; }        
        public int idRol { get; set; }
        public int idUsuario { get; set; }

        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
