using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerListadoCatalogoViewModel : IRequest<IEnumerable<ObtenerListadoCatalogoResponseViewModel>>
    {
        public int idCatalogo { get; set; }
        public string nombreCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public string usuarioConsulta { get; set; }
    }
}
