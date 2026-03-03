using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{
    public class ObtenerAprobacionesCentroCostosViewModel : IRequest<ObtenerAprobacionesCentroCostosResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string centroCostos { get; set; }
    }
}
