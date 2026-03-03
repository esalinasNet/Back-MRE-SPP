using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerProyectoPorIdViewModel : IRequest<ObtenerProyectoPorIdResponseViewModel>
    {
        public int idProgramacionProyecto { get; set; }
        public string usuarioConsulta { get; set; }
    }
}