using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Command
{
    public class AgregarProductoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProducto { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string producto { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
