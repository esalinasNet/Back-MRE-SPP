using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class ActualizarCatalogoItemViewModel : IRequest<CommandResponseViewModel>
    {
        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }
 
        public string descripcionCatalogoItem { get; set; }
        public string AbreviaturaCatalogoItem { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }

        public string detalleCatalogoItem { get; set; }
    }

    //public class AgregarCatalogoItemItemValidator : AbstractValidator<AgregarCatalogoItemItemViewModel>
    //{
    //    public AgregarCatalogoItemItemValidator()
    //    {
    //       // RuleFor(x => x.idProceso).NotNull().NotEmpty();
    //       // RuleFor(x => x.idEtapa).NotNull().NotEmpty();
    //       // RuleFor(x => x.idCentroTrabajo).NotNull().NotEmpty();
    //    }
    //}
}
