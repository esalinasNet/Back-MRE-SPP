using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas
{
    public class ObtenerProgramacionTareasPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        
        public int idProgramacionActividad { get; set; }
        //public int idProgramacionClasificador { get; set; }

        public string codigoTareas { get; set; }
        //public string descripcionTareas { get; set; }        

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
