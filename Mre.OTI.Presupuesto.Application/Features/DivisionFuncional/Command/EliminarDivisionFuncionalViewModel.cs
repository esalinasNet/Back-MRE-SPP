using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Command
{
    public class EliminarDivisionFuncionalViewModel : IRequest<CommandResponseViewModel>
    {
        public int idDivisionFuncional { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
