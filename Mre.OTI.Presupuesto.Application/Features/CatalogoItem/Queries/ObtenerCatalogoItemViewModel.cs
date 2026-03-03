using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerCatalogoItemViewModel : IRequest<ObtenerCatalogoItemResponseViewModel>
    {
        public int idCatalogoItem { get; set; }
        public string usuarioConsulta { get; set; }
    }
}
