using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Command
{    
    public class EliminarPlanillasViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPlanillas { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }

}
