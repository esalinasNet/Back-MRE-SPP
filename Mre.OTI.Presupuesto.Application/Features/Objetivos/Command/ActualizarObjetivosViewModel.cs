using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Command
{
    public class ActualizarObjetivosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idObjetivos { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }

        public int idPoliticas { get; set; }
        //public string codigoPrioritarios { get; set; }
        //public string descripcionPrioritarios { get; set; }

        public int idEstado { get; set; }
        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
