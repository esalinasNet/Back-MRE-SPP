using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerListadoProgramacionAccionesPorTareasViewModel : IRequest<IEnumerable<ObtenerListadoProgramacionAccionesResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
    }
}
