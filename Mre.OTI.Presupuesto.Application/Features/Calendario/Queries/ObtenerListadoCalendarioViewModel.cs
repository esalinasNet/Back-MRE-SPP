using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Queries
{
    public class ObtenerListadoCalendarioViewModel : IRequest<IEnumerable<ObtenerListadoCalendarioResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
