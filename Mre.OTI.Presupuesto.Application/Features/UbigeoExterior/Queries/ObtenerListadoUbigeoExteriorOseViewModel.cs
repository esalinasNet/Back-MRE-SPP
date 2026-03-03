using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerListadoUbigeoExteriorOseViewModel : IRequest<IEnumerable<ObtenerListadoUbigeoExteriorOseResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public string codigoRegion { get; set; }
        public string codigoPais { get; set; }
    }
}
