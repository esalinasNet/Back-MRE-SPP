using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerListadoUbigeoDepartamentoViewModel : IRequest<IEnumerable<ObtenerListadoUbigeoDepartamentoResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
