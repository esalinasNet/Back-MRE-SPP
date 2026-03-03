using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Command
{
    public class AgregarSubProgramaViewModel : IRequest<CommandResponseViewModel>
    {
        public int idSubPrograma { get; set; }
        public int idAnio { get; set; }
        public string subprograma { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
