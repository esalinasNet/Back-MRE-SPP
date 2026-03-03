using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerCatalogoViewModel : IRequest<ObtenerCatalogoResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idCatalogo { get; set; }
        //  

        //    public int draw { get; set; }


        //    public int paginaActual { get; set; }
        //    public int tamanioPagina { get; set; }
        //}

        //public class ObtenerObjetivoSectorialPaginadoValidator : AbstractValidator<ObtenerObjetivoSectorialPaginadoViewModel>
        //{
        //    public ObtenerObjetivoSectorialPaginadoValidator()
        //    {
        //        RuleFor(x => x.anio).NotNull().NotEmpty().WithMessage("INGRESE AÑO");
        //    }
        //}
    }
}
