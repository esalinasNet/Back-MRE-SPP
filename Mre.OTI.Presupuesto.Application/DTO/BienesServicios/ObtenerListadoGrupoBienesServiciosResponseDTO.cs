using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.BienesServicios
{
    public class ObtenerListadoGrupoBienesServiciosResponseDTO
    {
        public int idGrupo { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string tipoBien { get; set; }
        public string grupoBien { get; set; }        
        public string nombreBien { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        
    }
}
