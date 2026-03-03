using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class ActualizarUsuarioViewModel : IRequest<CommandResponseViewModel>
    {

        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public string clave { get; set; }
        public string login { get; set; }

        public string correo { get; set; }
        public string usuarioNT { get; set; }
        public string claveNT { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }

        public int isMre { get; set; }
    }

    //public class AgregarCatalogoItemValidator : AbstractValidator<AgregarCatalogoItemViewModel>
    //{
    //    public AgregarCatalogoItemValidator()
    //    {
    //       // RuleFor(x => x.idProceso).NotNull().NotEmpty();
    //       // RuleFor(x => x.idEtapa).NotNull().NotEmpty();
    //       // RuleFor(x => x.idCentroTrabajo).NotNull().NotEmpty();
    //    }
    //}
}
