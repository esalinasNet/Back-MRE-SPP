using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Command
{
    public class AgregarCalendarioViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPeriodo { get; set; }
        public int idAnio { get; set; }        
        public int idMes { get; set; }                
        public int idCentroCostos { get; set; }        
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }

    }
}
