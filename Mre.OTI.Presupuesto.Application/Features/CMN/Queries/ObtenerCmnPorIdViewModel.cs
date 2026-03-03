using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Queries
{
    public class ObtenerCmnPorIdViewModel : IRequest<ObtenerCmnPorIdResponseViewModel>
    {
        public int idProgramacionCmn { get; set; }
        public string usuarioConsulta { get; set; }
    }
}