using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Queries
{
    public class ObtenerRecursoPorIdViewModel : IRequest<ObtenerRecursoPorIdResponseViewModel>
    {
        public int idProgramacionRecurso { get; set; }
        public string usuarioConsulta { get; set; }
    }
}