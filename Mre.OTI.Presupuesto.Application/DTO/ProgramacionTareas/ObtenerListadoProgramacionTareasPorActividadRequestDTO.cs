using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas
{
    public class ObtenerListadoProgramacionTareasPorActividadRequestDTO
    {
        public int idAnio { get; set; }
        public int idProgramacionActividad { get; set; }
        //public int idProgramacionClasificador { get; set; }
    }
}
