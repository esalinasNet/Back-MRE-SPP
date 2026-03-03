using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Command
{
    public class AgregarAprobacionesCostosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAprobaciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
                
        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string descripcionCostos { get; set; }

        public int idEstado { get; set; }
        public bool? activo { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
