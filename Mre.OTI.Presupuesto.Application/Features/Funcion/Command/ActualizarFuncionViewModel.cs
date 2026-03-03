using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Command
{
    public class ActualizarFuncionViewModel : IRequest<CommandResponseViewModel>
    {
        public int idFuncion { get; set; }
        public int idAnio { get; set; }
        public string funcion { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public bool activo { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
