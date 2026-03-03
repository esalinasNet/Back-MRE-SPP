using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Command
{
    public class AgregarCatalogoViewModel : IRequest<CommandResponseViewModel>
    {

        public int idCatalogo { get; set; }
        public string descripcionCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public bool manteniblePorUsuario { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }


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
