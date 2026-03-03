using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class EliminarCatalogoItemViewModel : IRequest<CommandResponseViewModel>
    {

        public int idCatalogoItem { get; set; }
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
