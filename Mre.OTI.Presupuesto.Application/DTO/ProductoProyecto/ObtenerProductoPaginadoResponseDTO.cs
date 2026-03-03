using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProductoProyecto
{
    public class ObtenerProductoPaginadoResponseDTO
    {
        public int idProducto { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string producto { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
