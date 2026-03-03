using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries
{
    public class ObtenerListadoProductoViewModel : IRequest<IEnumerable<ObtenerListadoProductoResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
