using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class ActualizarRolViewModel : IRequest<CommandResponseViewModel>
    {

        public int idRol { get; set; }
        public int codigoRol { get; set; }
        public int idSistema { get; set; }
        public string nombre { get; set; }        
        public string descripcion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }


    }
}
