using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadViewModel : IRequest<ObtenerProgramacionActividadResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionActividad { get; set; }
    }
}
