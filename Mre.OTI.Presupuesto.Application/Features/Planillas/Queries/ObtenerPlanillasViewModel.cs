using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerPlanillasViewModel : IRequest<ObtenerPlanillasResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPlanillas { get; set; }
        public int idMes { get; set; }

    }
}
