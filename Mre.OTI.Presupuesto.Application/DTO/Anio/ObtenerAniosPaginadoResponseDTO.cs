using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Anio
{
    public class ObtenerAniosPaginadoResponseDTO
    {        
        public int idAnio { get; set; }
        public int anio { get; set; }     
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
