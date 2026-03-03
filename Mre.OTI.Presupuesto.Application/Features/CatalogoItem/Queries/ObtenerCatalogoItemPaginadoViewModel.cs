using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerCatalogoItemPaginadoViewModel : IRequest<dtCatalogoItemPaginadoResponseViewModel>
    {

        public int idCatalogo { get; set; }
        public string usuarioConsulta { get; set; }

        public int draw { get; set; }


        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }

    //public class ObtenerObjetivoSectorialPaginadoValidator : AbstractValidator<ObtenerObjetivoSectorialPaginadoViewModel>
    //{
    //    public ObtenerObjetivoSectorialPaginadoValidator()
    //    {
    //        RuleFor(x => x.anio).NotNull().NotEmpty().WithMessage("INGRESE AÑO");
    //    }
    //}
}
