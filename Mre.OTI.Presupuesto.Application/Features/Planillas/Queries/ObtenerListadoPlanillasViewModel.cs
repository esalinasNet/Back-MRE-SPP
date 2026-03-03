using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerListadoPlanillasViewModel : IRequest<IEnumerable<ObtenerListadoPlanillasResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public int idMes { get; set; }
    }
}
