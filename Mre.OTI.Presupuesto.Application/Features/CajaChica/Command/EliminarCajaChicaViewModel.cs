using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Command
{
    public class EliminarCajaChicaViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionCajaChica { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}