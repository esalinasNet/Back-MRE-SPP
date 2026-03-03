using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.UnidadMedida
{
    public class ObtenerListadoUnidadMedidaResponseDTO
    {
        public int idUnidadMedida { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string unidadMedida { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
