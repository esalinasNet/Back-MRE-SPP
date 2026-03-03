using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones
{
    public class ObtenerListadoProgramacionAccionesPorTareasRequestDTO
    {
        public int idAnio { get; set; }
        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
    }
}
