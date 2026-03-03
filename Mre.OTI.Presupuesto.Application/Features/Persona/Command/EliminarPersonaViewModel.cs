using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Command
{
    public class EliminarPersonaViewModel : IRequest<CommandResponseViewModel>
    {

        public int idPersona { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }


    }
}
