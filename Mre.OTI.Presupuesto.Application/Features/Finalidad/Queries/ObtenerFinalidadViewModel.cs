using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries
{
    public class ObtenerFinalidadViewModel : IRequest<ObtenerFinalidadResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idFinalidad { get; set; }
    }
}
