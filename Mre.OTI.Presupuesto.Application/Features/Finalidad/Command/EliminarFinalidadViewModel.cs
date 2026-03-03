using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Command
{
    public class EliminarFinalidadViewModel : IRequest<CommandResponseViewModel>
    {
        public int idFinalidad { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
