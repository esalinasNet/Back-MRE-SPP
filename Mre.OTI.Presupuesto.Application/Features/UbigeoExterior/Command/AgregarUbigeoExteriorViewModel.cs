using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Command
{
    public class AgregarUbigeoExteriorViewModel : IRequest<CommandResponseViewModel>
    {
        public string item { get; set; }
        public string zone { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string oseRes { get; set; }
        public string ose { get; set; }
        public string tipoMision { get; set; }
        public string nombreOse { get; set; }
        public string moneda { get; set; }
        public string mon { get; set; }
        public int idEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
