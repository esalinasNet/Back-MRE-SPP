using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Command
{
    public class AgregarFinalidadViewModel : IRequest<CommandResponseViewModel>
    {
        public int idFinalidad { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string finalidad { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
