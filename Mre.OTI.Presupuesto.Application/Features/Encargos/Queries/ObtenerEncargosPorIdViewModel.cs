using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerEncargosPorIdViewModel : IRequest<ObtenerEncargosPorIdResponseViewModel>
    {
        public int idProgramacionEncargos { get; set; }
        public string usuarioConsulta { get; set; }
    }
}