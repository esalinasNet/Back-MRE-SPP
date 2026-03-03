using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Command
{
    public class EliminarSubProgramaViewModel : IRequest<CommandResponseViewModel>
    {
        public int idSubPrograma { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}

