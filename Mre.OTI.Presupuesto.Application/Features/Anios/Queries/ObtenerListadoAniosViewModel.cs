using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Anios.Queries
{
    public class ObtenerListadoAniosViewModel : IRequest<IEnumerable<ObtenerListadoAniosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
