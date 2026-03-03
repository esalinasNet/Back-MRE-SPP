using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAnios.Command
{
    public class CopiarProgramacionAniosViewModel : IRequest<CommandResponseViewModel>
    {
        public int anioOrigen { get; set; }
        public List<int> aniosDestino { get; set; }
        public List<int> actividades { get; set; }
        public string ipCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}