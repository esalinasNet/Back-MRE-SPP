using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Command
{
    public class ActualizarProgramacionActividadObservadoViewModel : IRequest<CommandResponseViewModel>
    {    
        public int idProgramacionActividad { get; set; }
        public int idAnio { get; set; }
     
        public string codigoProgramacion { get; set; }

        public string observacion { get; set; }

        public int idEstado { get; set; }

        public int idAprobaciones { get; set; }
        public int idCentroCostosDestino { get; set; }
        public int idCentroCostosOrigen { get; set; }
        public int idAprobacionesDetalle { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
