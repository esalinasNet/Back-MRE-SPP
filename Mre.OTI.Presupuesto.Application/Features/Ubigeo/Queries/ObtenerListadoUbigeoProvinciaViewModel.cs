using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerListadoUbigeoProvinciaViewModel : IRequest<IEnumerable<ObtenerListadoUbigeoProvinciaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public string departamento { get; set; }
    }
}
