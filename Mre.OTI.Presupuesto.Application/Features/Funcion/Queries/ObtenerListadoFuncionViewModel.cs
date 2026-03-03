using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Queries
{
    public class ObtenerListadoFuncionViewModel : IRequest<IEnumerable<ObtenerListadoFuncionResponseViewModel>>
    {        
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
