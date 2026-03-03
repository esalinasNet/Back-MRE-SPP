using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerCodigoProgramacionAccionesViewModel : IRequest<ObtenerCodigoProgramacionAccionesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string codigoAcciones { get; set; }
    }
}
