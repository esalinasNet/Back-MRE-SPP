using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Command
{
    public class EliminarPlanillasDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPlanillaDetalle { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
