using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Queries
{
    public class ObtenerAprobacionesCostosDetalleViewModel : IRequest<ObtenerAprobacionesCostosDetalleResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idAprobacionesDetalle { get; set; }
    }
}
