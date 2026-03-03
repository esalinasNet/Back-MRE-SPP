using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Command
{
    public class AgregarComponenteViewModel : IRequest<CommandResponseViewModel>
    {
        public int idComponente { get; set; }
        public int idAnio { get; set; }
        public string componente { get; set; }
        public string tipoComponente { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
