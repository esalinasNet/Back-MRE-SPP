using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Command
{
    public class ActualizarAprobacionesCostosDetalleViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAprobacionesDetalle { get; set; }

        public int idAprobaciones { get; set; }

        public int idPersona { get; set; }

        public string nombresApellidos { get; set; }

        public int idCentroCostos { get; set; }

        public string centroCostos { get; set; }

        public string descripcionCentroCostos { get; set; }

        public string puestoTrabajo { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public int idEstado { get; set; }

        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
