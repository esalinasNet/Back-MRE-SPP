using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Command
{
    public class EliminarObjetivosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idObjetivos { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
