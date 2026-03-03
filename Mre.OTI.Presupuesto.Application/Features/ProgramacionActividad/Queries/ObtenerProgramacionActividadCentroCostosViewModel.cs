using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadCentroCostosViewModel : IRequest<IEnumerable<ObtenerProgramacionActividadCentroCostosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public int idCentroCostos { get; set; }
    }
}
