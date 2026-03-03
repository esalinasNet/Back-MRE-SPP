using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerListadoProgramacionTareasPorActividadViewModel : IRequest<IEnumerable<ObtenerListadoProgramacionTareasResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public int idProgramacionActividad { get; set; }
        //public int idProgramacionClasificador { get; set; }
    }
}
