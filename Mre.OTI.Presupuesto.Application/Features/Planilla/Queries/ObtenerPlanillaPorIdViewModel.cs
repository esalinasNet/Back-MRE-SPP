using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planilla;

namespace Mre.OTI.Presupuesto.Application.Features.Planilla.Queries
{
    public class ObtenerPlanillaPorIdViewModel : IRequest<ObtenerPlanillaPorIdResponseViewModel>
    {
        public int idProgramacionPlanilla { get; set; }
        public string usuarioConsulta { get; set; }
    }
}