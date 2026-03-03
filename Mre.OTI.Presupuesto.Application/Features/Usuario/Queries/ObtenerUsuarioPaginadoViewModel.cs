using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerUsuarioPaginadoViewModel : IRequest<dtUsuarioPaginadoResponseViewModel>
    {
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string correo { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
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
