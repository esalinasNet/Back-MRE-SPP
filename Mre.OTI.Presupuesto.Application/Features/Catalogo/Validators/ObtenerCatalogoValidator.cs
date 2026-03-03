using FluentValidation;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;


namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Validators
{
    public class ObtenerCatalogoValidator : AbstractValidator<ObtenerCatalogoViewModel>
    {
        public ObtenerCatalogoValidator()
        {
            RuleFor(x => x.idCatalogo)
                         .GreaterThan(0).WithMessage("idCatalogo es requerido")
                         .NotEmpty().WithMessage("idCatalogo es requerido.");

            
        }
    }
}
