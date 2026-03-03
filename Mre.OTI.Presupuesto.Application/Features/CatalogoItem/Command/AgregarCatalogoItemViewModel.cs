using FluentValidation;
using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class AgregarCatalogoItemViewModel : IRequest<CommandResponseViewModel>
    {
        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }

        public string detalleCatalogoItem { get; set; }
        //public int orden { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string AbreviaturaCatalogoItem { get; set; }

        public bool eliminado { get; set; }
        public bool activo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }



    }

    public class AgregarCatalogoItemValidator : AbstractValidator<AgregarCatalogoItemViewModel>
    {
        public AgregarCatalogoItemValidator()
        {
            // RuleFor(x => x.idProceso).NotNull().NotEmpty();
            // RuleFor(x => x.idEtapa).NotNull().NotEmpty();
            // RuleFor(x => x.idCentroTrabajo).NotNull().NotEmpty();
        }
    }
}
