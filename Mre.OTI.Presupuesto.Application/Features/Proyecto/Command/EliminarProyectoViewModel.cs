using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Command
{
    public class EliminarProyectoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionProyecto { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}