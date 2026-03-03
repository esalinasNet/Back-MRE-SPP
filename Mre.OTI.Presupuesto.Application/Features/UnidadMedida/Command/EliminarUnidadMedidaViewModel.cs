using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command
{
    public class EliminarUnidadMedidaViewModel : IRequest<CommandResponseViewModel>
    {
        public int idUnidadMedida { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
