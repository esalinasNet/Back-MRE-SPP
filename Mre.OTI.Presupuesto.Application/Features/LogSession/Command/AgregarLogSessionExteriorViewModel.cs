using MediatR;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.LogSession.Command
{
    public class AgregarLogSessionExteriorViewModel : IRequest<CommandResponseViewModel>
    {
        public string usuarioLogout { get; set; }
        public string ipCreacion { get; set; }
        public string token { get; set; }
        public string dispositivo
        {
            get; set;
        }

    }
}
