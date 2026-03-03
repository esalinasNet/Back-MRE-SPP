using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using Mre.OTI.Presupuesto.Application.Responses.Planillas_Detalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Queries
{
    public class ObtenerPlanillasDetalleViewModel : IRequest<ObtenerPlanillasDetalleResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPlanillaDetalle { get; set; }
    }
}
