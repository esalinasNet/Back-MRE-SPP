using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerListadoUsuarioViewModel : IRequest<IEnumerable<ObtenerListadoUsuarioResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idRol { get; set; }
    }
}
