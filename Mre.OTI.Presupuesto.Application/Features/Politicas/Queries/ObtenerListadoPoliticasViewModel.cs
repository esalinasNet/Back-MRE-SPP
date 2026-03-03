using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Queries
{
    public class ObtenerListadoPoliticasViewModel : IRequest<IEnumerable<ObtenerListadoPoliticasResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
