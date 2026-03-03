using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerCajaChicaPorIdViewModel : IRequest<ObtenerCajaChicaPorIdResponseViewModel>
    {
        public int idProgramacionCajaChica { get; set; }
        public string usuarioConsulta { get; set; }
    }
}