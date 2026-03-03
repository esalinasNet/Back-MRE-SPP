using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Command
{
    public class EliminarBienesServiciosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idBienesServicios { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
