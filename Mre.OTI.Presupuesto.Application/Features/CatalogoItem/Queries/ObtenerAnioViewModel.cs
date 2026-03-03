using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerAnioViewModel : IRequest<IEnumerable<CatalogoItemViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
