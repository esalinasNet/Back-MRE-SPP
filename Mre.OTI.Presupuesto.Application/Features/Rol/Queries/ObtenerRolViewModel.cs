using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Rol;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerRolViewModel : IRequest<ObtenerRolResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idRol { get; set; }

    }
}
