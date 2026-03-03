using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Command
{
    public class AgregarTipoDeCambioViewModel : IRequest<CommandResponseViewModel>
    {
        //public int idMoneda { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoIso { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        //public bool activo { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
