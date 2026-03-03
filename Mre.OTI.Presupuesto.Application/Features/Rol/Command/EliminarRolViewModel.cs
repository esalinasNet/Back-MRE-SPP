using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class EliminarRolViewModel : IRequest<CommandResponseViewModel>
    {

        public int idRol { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }


    }
}
