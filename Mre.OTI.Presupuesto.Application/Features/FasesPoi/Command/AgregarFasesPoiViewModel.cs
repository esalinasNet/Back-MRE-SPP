using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Command
{
    public class AgregarFasesPoiViewModel : IRequest<CommandResponseViewModel>
    {
        public int idFasesPoi { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoFases { get; set; }
        public string descripcionFases { get; set; }

        public int anioInicial { get; set; }
        public int anioFinal { get; set; }

        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
