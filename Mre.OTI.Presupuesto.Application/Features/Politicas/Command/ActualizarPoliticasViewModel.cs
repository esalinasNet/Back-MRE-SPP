using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Command
{
    public class ActualizarPoliticasViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPoliticas { get; set; }
        public int idAnio { get; set; }
        public string codigoPoliticas { get; set; }
        public string descripcionPoliticas { get; set; }
        public string codigoObjetivo { get; set; }
        public string descripcionObjetivo { get; set; }
        public string codigoLinemiento { get; set; }
        public string descripcionLineamiento { get; set; }
        public string codigoServicio { get; set; }
        public string descripcionServicio { get; set; }
        public int idEstado { get; set; }
        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
