using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Command
{
    public class EliminarAprobacionesCostosDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAprobacionesDetalle { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
