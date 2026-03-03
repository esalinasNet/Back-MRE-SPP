using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Command
{
    public class EliminarFasesPoiViewModel : IRequest<CommandResponseViewModel>
    {
        public int idFasesPoi { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
