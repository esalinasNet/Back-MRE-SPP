using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries
{
    public class ObtenerProductoViewModel : IRequest<ObtenerProductoResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProducto { get; set; }
    }
}
