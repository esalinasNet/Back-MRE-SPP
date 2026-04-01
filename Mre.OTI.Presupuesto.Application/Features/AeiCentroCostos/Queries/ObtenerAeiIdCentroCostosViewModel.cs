using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiIdCentroCostosViewModel : IRequest<IEnumerable<ObtenerAeiIdCentroCostosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }        
        public int idCentroCostos { get; set; }
    }
}
