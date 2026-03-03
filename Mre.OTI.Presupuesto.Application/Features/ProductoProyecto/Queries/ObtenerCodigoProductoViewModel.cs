using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries
{
    public class ObtenerCodigoProductoViewModel : IRequest<ObtenerCodigoProductoResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string producto { get; set; }
    }
}
