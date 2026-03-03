using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Queries
{
    public class ObtenerCalendarioViewModel : IRequest<ObtenerCalendarioResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPeriodo { get; set; }

    }
}
