using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Command
{
    public class ActualizarPlanillasDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPlanillaDetalle { get; set; }

        public int idPlanillas { get; set; }

        public int idEspecifica { get; set; }
                
        //public DateTime Periodo { get; set; }

        public decimal Importe { get; set; }

        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
