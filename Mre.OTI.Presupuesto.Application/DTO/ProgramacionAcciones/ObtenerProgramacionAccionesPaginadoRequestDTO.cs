using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones
{
    public class ObtenerProgramacionAccionesPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
        public string codigoAcciones { get; set; }
        
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
