using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerCodigoPlanillasViewModel : IRequest<ObtenerCodigoPlanillasResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public int Mes { get; set; }
        public string nroDocumento { get; set; }
    }
}
