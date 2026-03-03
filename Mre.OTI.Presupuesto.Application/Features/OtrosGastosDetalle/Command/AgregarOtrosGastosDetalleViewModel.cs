using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastosDetalle.Command
{
    public class AgregarOtrosGastosDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionOtrosGastosDetalle { get; set; } = 0;
        public int idProgramacionOtrosGastos { get; set; }
        public string generico { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal monto { get; set; }  // AGREGADO
        public decimal valor { get; set; }
        public int mes { get; set; }

        public string ipCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}