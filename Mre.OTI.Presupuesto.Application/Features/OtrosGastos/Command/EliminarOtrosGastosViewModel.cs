using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Command
{
    public class EliminarOtrosGastosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionOtrosGastos { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}