using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerCodigoAccionesViewModel : IRequest<ObtenerCodigoAccionesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string codigoAcciones { get; set; }
    }
}
