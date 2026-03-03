using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries
{
    public class ObtenerOtrosGastosPorIdViewModel : IRequest<ObtenerOtrosGastosPorIdResponseViewModel>
    {
        public int idProgramacionOtrosGastos { get; set; }
        public string usuarioConsulta { get; set; }
    }
}