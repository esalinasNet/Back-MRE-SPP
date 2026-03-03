using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.EncargosDetalle.Command
{
    public class AgregarEncargosDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionEncargosDetalle { get; set; } = 0;
        public int idProgramacionEncargos { get; set; }
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