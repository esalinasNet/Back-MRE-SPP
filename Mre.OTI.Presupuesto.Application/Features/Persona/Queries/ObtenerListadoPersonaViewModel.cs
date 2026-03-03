using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerListadoPersonaViewModel : IRequest<IEnumerable<ObtenerListadoPersonaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
