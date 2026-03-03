using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Command
{
    public class AgregarCentroCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idCentroCostos { get; set; }
        public int idAnio { get; set; }
        public int idEjecutora { get; set; }        
        public string centroCostos { get; set; }
        public string descripcion { get; set; }
        public string centroCostosPadre { get; set; }
        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }

    }
}
