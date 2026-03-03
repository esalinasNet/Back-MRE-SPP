using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerUsuarioViewModel : IRequest<ObtenerUsuarioResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idUsuario { get; set; }

    }
}
