using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Command
{
    public class EliminarAprobacionesCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAprobaciones { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
