using FluentValidation;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;


namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Validators
{
    public class ObtenerCatalogoPaginadoValidator : AbstractValidator<ObtenerCatalogoPaginadoViewModel>
    {
        public ObtenerCatalogoPaginadoValidator()
        {
            RuleFor(x => x.paginaActual)
                         .GreaterThan(0).WithMessage("Ingrese numero de pagina")
                         .NotEmpty().WithMessage("pagina actual es requerido.");

            RuleFor(x => x.tamanioPagina)
               .GreaterThan(0).WithMessage("Ingrese tamaño de pagina")
                         .NotEmpty().WithMessage("tamaño de pagina   es requerido.");

            //RuleFor(x => x.UsuarioCreacion)
            //    .NotEmpty().WithMessage("El usuario de creación es obligatorio.")
            //    .MaximumLength(20).WithMessage("El usuario de creación no puede superar los 20 caracteres.");

            //RuleFor(x => x.IpCreacion)
            //    .NotEmpty().WithMessage("La IP de creación es obligatoria.")
            //    .MaximumLength(40).WithMessage("La IP de creación no puede superar los 40 caracteres.");
        }
    }
}
