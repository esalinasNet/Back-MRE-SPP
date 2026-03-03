using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerListadoAccionesInstitucionalesViewModel : IRequest<IEnumerable<ObtenerListadoAccionesInstitucionalesResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
