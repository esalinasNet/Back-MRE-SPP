using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerListadoRolViewModel : IRequest<IEnumerable<ObtenerListadoRolResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idSistema { get; set; }
    }
}
