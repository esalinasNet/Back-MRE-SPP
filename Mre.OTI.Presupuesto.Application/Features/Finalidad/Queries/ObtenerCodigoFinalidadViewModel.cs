using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries
{
    public class ObtenerCodigoFinalidadViewModel : IRequest<ObtenerCodigoFinalidadResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string finalidad { get; set; }
    }
}
