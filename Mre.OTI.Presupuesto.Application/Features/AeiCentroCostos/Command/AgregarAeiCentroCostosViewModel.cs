using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command
{
    public class AgregarAeiCentroCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAnio { get; set; }
        public int idAcciones { get; set; }
        public int idCentroCostos { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
