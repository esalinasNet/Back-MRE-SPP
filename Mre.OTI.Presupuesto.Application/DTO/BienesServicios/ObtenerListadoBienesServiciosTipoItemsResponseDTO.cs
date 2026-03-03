using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.BienesServicios
{
    public class ObtenerListadoBienesServiciosTipoItemsResponseDTO
    {
        public int idBienesServicios { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoBien { get; set; }
        public string nombreBien { get; set; }
        public string tipoItems { get; set; }

        public int idUnidadMedida { get; set; }
        public string descripcionUinidadMedida { get; set; }

        public decimal precio { get; set; }

        public int idClasificador { get; set; }
        public string clasificadorGasto { get; set; }
        public string descripcionClasificador { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
