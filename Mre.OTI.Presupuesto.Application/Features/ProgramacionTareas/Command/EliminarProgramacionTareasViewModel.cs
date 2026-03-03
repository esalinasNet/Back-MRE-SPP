using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Command
{
    public class EliminarProgramacionTareasViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionTareas { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
