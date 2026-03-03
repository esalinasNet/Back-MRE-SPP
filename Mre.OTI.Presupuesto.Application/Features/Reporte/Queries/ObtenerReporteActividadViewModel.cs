using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;

namespace Mre.OTI.Presupuesto.Application.Features.Reporte.Queries
{
    public class ObtenerReporteActividadViewModel : IRequest<ObtenerReporteActividadResponseViewModel>
    {
        public int idProgramacionActividad { get; set; }
        public string usuarioConsulta { get; set; }
    }
}