using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.AccionesInstitucionales
{
    public class ObtenerAccionesInstitucionalesResponseDTO
    {
        public int idAcciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }

        public int nroCentroCostos { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
