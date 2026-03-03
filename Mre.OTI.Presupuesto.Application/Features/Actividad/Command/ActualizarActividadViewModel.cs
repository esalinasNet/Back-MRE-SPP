using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Command
{
    public class ActualizarActividadViewModel : IRequest<CommandResponseViewModel>
    {
        public int idActividad { get; set; }
        public int idAnio { get; set; }
        public string actividad { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public bool activo { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}