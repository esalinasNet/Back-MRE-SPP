using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command
{
    public class ActualizarUsuarioRolViewModel : IRequest<CommandResponseViewModel>
    {
        public int idUsuarioRol { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int idCentroCostos { get; set; }

        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }    
        
    }
}
