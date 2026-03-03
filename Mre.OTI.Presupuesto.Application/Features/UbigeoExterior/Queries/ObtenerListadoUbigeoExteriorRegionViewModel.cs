using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerListadoUbigeoExteriorRegionViewModel : IRequest<IEnumerable<ObtenerListadoUbigeoExteriorRegionResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
