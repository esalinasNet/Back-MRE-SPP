using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Command
{
    public class ActualizarUbigeoProvinciaViewModel : IRequest<CommandResponseViewModel>
    {
        public int idUbigeo { get; set; }
        //public string pais { get; set; }
        //public string ubigeo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        //public string distrito { get; set; }
        public string descripcion { get; set; }
        //public int idEstado { get; set; }
        public bool activo { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}