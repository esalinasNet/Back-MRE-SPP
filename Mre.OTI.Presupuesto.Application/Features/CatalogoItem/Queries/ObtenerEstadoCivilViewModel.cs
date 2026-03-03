using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerEstadoCivilViewModel : IRequest<IEnumerable<CatalogoItemViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
