using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class AgregarRolViewModel : IRequest<CommandResponseViewModel>
    {

        //public int idRol { get; set; }
        public int codigoRol { get; set; }
        public int idSistema { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }

        
    }
}
