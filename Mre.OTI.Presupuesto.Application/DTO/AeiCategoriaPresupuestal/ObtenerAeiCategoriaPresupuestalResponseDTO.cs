using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.AeiCategoriaPresupuestal
{
    public class ObtenerAeiCategoriaPresupuestalResponseDTO
    {
        public int idAeiPresupuestal { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public int idPresupuestal { get; set; }
        public string codigoPresupuestal { get; set; }
        public string descripcionPresupuestal { get; set; }

        public int idAcciones { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public bool? activo { get; set; }
    }
}
