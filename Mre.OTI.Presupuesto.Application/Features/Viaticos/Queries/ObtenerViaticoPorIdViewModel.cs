using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Viaticos;

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries
{
    public class ObtenerViaticoPorIdViewModel : IRequest<ObtenerViaticoPorIdResponseViewModel>
    {
        public int idProgramacionViaticos { get; set; }
        public string usuarioConsulta { get; set; }
    }
}