using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerListadoComponenteViewModel : IRequest<IEnumerable<ObtenerListadoComponenteResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
