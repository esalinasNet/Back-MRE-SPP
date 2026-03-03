using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Command
{
    public class AgregarPaisesViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPaises { get; set; }
        public string codigo { get; set; }
        public string nombre_pais { get; set; }
        public string continente { get; set; }
        public int idEstado { get; set; }        
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
