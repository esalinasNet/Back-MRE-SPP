using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Command
{
    public class ActualizarProgramacionAccionesViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionAcciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idProgramacionTareas { get; set; }
        public string codigoTareas { get; set; }

        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public int idUnidadMedida { get; set; }
        public string descripcionUnidadMedida { get; set; }

        public bool? representativa { get; set; }
        public bool? acumulativa { get; set; }

        public int metaFisica { get; set; }

        public int enero { get; set; }
        public int febrero { get; set; }
        public int marzo { get; set; }
        public int abril { get; set; }
        public int mayo { get; set; }
        public int junio { get; set; }
        public int julio { get; set; }
        public int agosto { get; set; }
        public int setiembre { get; set; }
        public int octubre { get; set; }
        public int noviembre { get; set; }
        public int diciembre { get; set; }

        public int totalAnual { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
