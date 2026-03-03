using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.CategoriaPresupuestal
{
    public class ObtenerCategoriaPresupuestalPaginadoResponseDTO
    {
        public int idPresupuestal { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoPresupuestal { get; set; }
        public string descripcionPresupuestal { get; set; }

        public int idAcciones { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public int nroCodigoAcciones { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
