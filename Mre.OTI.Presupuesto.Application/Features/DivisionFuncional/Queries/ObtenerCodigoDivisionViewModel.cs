using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerCodigoDivisionViewModel : IRequest<ObtenerCodigoDivisionResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string divisionFuncional { get; set; }
    }
}
