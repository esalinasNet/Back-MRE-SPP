using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerListadoUbigeoExteriorPaisViewModel : IRequest<IEnumerable<ObtenerListadoUbigeoExteriorPaisResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public string codigoRegion { get; set; }
    }
}
