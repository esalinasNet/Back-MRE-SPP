using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command
{
    public class EliminarAeiCentroCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAnio { get; set; }
        public int idAcciones { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
