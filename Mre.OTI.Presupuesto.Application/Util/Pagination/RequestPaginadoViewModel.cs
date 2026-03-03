using MediatR;

namespace Mre.OTI.Presupuesto.Application.Util.Pagination
{
    public class RequestPaginadoViewModel<T> : IRequest<T>
    {
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
