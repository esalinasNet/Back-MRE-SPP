using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.FuenteFinanciamiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.FuenteFinanciamiento.Queries
{
    public class ObtenerListadoFuenteFinanciamientoViewModel : IRequest<IEnumerable<ObtenerListadoFuenteFinanciamientoResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
