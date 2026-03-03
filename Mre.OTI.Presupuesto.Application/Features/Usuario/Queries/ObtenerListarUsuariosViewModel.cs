using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerListarUsuariosViewModel : IRequest<IEnumerable<ObtenerListarUsuariosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
