using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Command
{
    public  class AgregarAprobacionesCostosDetalleViewModel : IRequest<CommandResponseViewModel>
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

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }

    }
}
