using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries
{
    public class ObtenerCodigoCostosViewModel : IRequest<ObtenerCodigoCostosResponseViewModel>
    {

        public string usuarioConsulta { get; set; }
        public string centroCostos { get; set; }
    }
}
