using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;

namespace Mre.OTI.Presupuesto.Application.Features.ReporteFinanciero.Queries
{
    public class ObtenerReporteFinancieroViewModel : IRequest<ObtenerReporteFinancieroResponseViewModel>
    {
        public int idProgramacionActividad { get; set; }
        public string usuarioConsulta { get; set; }
    }
}