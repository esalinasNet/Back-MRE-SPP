using FluentValidation;
using  Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;


namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Validators
{
    public class ActualizarCatalogoValidator : AbstractValidator<ActualizarCatalogoViewModel>
    {
        public ActualizarCatalogoValidator()
        {
            RuleFor(x => x.codigoCatalogo)
                         .GreaterThan(0).WithMessage("Ingrese codigo Catalogo")
                         .NotEmpty().WithMessage("La codigoCatalogo es obligatoria.");

            RuleFor(x => x.descripcionCatalogo)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.");


             

            //RuleFor(x => x.UsuarioCreacion)
            //    .NotEmpty().WithMessage("El usuario de creación es obligatorio.")
            //    .MaximumLength(20).WithMessage("El usuario de creación no puede superar los 20 caracteres.");

            //RuleFor(x => x.IpCreacion)
            //    .NotEmpty().WithMessage("La IP de creación es obligatoria.")
            //    .MaximumLength(40).WithMessage("La IP de creación no puede superar los 40 caracteres.");
        }
    }
}
