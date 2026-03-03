using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerListadoDivisionFuncionalViewModel : IRequest<IEnumerable<ObtenerListadoDivisionFuncionalResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
