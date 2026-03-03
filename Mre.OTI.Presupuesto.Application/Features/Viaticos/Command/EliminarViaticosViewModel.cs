using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Command
{
    public class EliminarViaticosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionViaticos { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}