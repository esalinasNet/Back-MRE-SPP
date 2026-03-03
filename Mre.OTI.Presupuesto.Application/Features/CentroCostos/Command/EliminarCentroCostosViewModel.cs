using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Command
{
    public class EliminarCentroCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idCentroCostos { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
