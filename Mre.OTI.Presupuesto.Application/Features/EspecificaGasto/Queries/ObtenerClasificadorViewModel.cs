using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerClasificadorViewModel : IRequest<ObtenerClasificadorResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public string Clasificador { get; set; }
    }
}
