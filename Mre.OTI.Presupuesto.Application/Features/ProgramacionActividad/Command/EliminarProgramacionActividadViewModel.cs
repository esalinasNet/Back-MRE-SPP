using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Command
{
    public class EliminarProgramacionActividadViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionActividad { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
