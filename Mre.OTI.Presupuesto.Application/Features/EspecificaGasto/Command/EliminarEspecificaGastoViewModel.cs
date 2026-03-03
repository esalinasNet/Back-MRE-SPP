using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Command
{
    public class EliminarEspecificaGastoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idClasificador { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
