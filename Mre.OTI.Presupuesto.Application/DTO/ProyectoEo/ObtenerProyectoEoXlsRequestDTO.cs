using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEo
{
    public class ObtenerProyectoEoXlsRequestDTO
    {
        public string nombreProyecto { get; set; }
        public int idTipoDocumento { get; set; }
        // public string numeroDocumento { get; set; }
        public bool? activo { get; set; }

        //public int idTipoDocumento { get; set; }
        public int idEstadoProyecto { get; set; }
        //public string nombreProyecto { get; set; }
        public int idPeriodo { get; set; }

        public int situacion { get; set; }
    }
}
