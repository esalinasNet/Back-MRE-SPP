using FluentValidation;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;


namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Validators
{
    public class EliminarCatalogoValidator : AbstractValidator<EliminarCatalogoViewModel>
    {
        public EliminarCatalogoValidator()
        {
            RuleFor(x => x.idCatalogo)
                         .GreaterThan(0).WithMessage("Ingrese numero de pagina")
                         .NotEmpty().WithMessage("pagina actual es requerido.");

           // RuleFor(x => x.usuarioModificacion)
                         //.Equal("0").WithMessage("usuarioModificacion es requerido")
                         //.NotEmpty().WithMessage("usuarioModificacion  es requerido.");

            //RuleFor(x => x.UsuarioCreacion)
            //    .NotEmpty().WithMessage("El usuario de creación es obligatorio.")
            //    .MaximumLength(20).WithMessage("El usuario de creación no puede superar los 20 caracteres.");

            //RuleFor(x => x.IpCreacion)
            //    .NotEmpty().WithMessage("La IP de creación es obligatoria.")
            //    .MaximumLength(40).WithMessage("La IP de creación no puede superar los 40 caracteres.");
        }
    }
}
