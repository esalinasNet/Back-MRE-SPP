using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command
{
    public class EliminarUsuarioRolViewModel : IRequest<CommandResponseViewModel>
    {

        public int idUsuarioRol { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }


    }
}
