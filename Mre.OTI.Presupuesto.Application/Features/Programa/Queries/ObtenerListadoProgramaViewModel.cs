using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Programa.Queries
{
    public class ObtenerListadoProgramaViewModel : IRequest<IEnumerable<ObtenerListadoProgramaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
