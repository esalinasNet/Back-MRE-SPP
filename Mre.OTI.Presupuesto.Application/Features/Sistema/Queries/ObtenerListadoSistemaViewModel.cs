using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Sistema.Queries
{
    public class ObtenerListadoSistemaViewModel : IRequest<IEnumerable<ObtenerListadoSistemaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }

    }
}
