using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UsuarioRol;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries
{
    public class ObtenerUsuarioRolViewModel : IRequest<ObtenerUsuarioRolResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idUsuarioRol { get; set; }

    }
}
