using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.ViaticosDetalle.Command
{
    public class AgregarViaticosDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionViaticosDetalle { get; set; } = 0;
        public int idProgramacionViaticos { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal monto { get; set; }
        public int cantidadPersonas { get; set; }
        public int dias { get; set; }
        public int mes { get; set; }

        public string ipCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}