using MediatR;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.LogSession.Command
{
    public class AgregarLogSessionViewModel : IRequest<CommandResponseViewModel>
    {
        public string token { get; set; }
        public string usuarioLogout { get; set; }
        public string ipCreacion { get; set; }
        public string dispositivo { get; set; } 

    }
}
