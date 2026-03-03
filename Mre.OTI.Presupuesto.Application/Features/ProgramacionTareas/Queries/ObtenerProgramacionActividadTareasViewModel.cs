using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerProgramacionActividadTareasViewModel : IRequest<ObtenerProgramacionActividadTareasResponseViewModel>
    {
        public string usuarioConsulta { get; set; }

        public int idProgramacionActividad { get; set; }
        //public int idProgramacionClasificador { get; set; }
    }
}
