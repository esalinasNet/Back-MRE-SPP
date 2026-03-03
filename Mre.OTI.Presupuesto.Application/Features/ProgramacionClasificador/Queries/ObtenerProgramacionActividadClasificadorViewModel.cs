using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerProgramacionActividadClasificadorViewModel : IRequest<ObtenerProgramacionActividadClasificadorResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionActividad { get; set; }
    }
}
