using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Queries
{
    public class ObtenerListadoPaisesViewModel : IRequest<IEnumerable<ObtenerListadoPaisesResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }

    }
}
