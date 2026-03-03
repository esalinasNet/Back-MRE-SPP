using MediatR;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class EliminarUsuarioViewModel : IRequest<int>
    {

        public int idUsuario { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }


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
