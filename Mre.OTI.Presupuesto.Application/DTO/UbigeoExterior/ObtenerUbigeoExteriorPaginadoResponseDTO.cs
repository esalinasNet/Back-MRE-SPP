using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.UbigeoExterior
{
    public class ObtenerUbigeoExteriorPaginadoResponseDTO
    {
        public int idUbigeoExterior { get; set; }
        public string item { get; set; }
        public string zone { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string oseRes { get; set; }
        public string ose { get; set; }
        public string tipoMision { get; set; }
        public string nombreOse { get; set; }
        public string moneda { get; set; }
        public string mon { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
