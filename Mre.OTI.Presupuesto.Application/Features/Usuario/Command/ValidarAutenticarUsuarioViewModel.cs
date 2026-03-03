using MediatR;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class ValidarAutenticarUsuarioViewModel : IRequest<bool>
    {
        public string token { get; set; }

    }

}
