using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerCodigoUnidadMedidaViewModel : IRequest<ObtenerCodigoUnidadMedidaResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string unidadMedida { get; set; }
    }
}
