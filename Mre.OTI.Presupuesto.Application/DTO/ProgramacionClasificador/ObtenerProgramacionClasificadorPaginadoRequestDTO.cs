using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador
{
    public class ObtenerProgramacionClasificadorPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public int idProgramacionActividad { get; set; }
        public string codigoClasificador { get; set; }
        public string descripcionClasificador { get; set; }
        
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

    }
}
