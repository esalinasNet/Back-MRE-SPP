using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Command
{
    public class ActualizarCatalogoViewModel : IRequest<CommandResponseViewModel>
    {

        public int idCatalogo { get; set; }
        public string descripcionCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public bool manteniblePorUsuario { get; set; }

        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
        public DateTime fechaCreacion { get; set; }

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
