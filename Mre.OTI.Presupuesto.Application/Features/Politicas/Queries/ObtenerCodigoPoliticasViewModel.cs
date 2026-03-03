using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Queries
{
    public class ObtenerCodigoPoliticasViewModel : IRequest<ObtenerCodigoPoliticasResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string codigoPoliticas { get; set; }

    }
}
