using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System.Collections;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command
{
    public class AgregarUsuarioRolViewModel : IRequest<CommandResponseViewModel>
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int accesoPrivado { get; set; }     
        public int idCentroCostos { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
