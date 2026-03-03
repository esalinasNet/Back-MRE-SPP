using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos
{
    public class ObtenerAprobacionesCostosResponseDTO
    {
        public int idAprobaciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string descripcionCentroCostos { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
