using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Persona;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerPersonaViewModel : IRequest<ObtenerPersonaResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPersona { get; set; }

    }
}
