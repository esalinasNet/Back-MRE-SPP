using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Planillas
{
    public class ObtenerCodigoPlanillasResponseDTO
    {
        public int idPlanillas { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idMes { get; set; }
        public int Mes { get; set; }
        public string descripcionMes { get; set; }

        public int idPrograma { get; set; }
        public string Programa { get; set; }
        public string descripcionPrograma { get; set; }

        public int idProducto { get; set; }
        public string Producto { get; set; }
        public string descripcionProducto { get; set; }

        public int idActividad { get; set; }
        public string Actividad { get; set; }
        public string descripcionActividad { get; set; }

        public int Meta { get; set; }

        public int idFinalidad { get; set; }
        public string Finalidad { get; set; }
        public string descripcionFinalidad { get; set; }

        public int idCentroCostos { get; set; }
        public string CentroCostos { get; set; }
        public string descripcionCentroCostos { get; set; }

        public int tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string apellidosNombres { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
