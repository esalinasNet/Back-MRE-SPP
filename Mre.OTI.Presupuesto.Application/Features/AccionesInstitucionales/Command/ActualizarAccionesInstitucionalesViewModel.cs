using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command
{
    public class ActualizarAccionesInstitucionalesViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAcciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }

        public int idEstado { get; set; }
        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
