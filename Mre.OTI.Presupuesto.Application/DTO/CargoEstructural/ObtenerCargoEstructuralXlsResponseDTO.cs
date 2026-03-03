using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructural
{
    public class ObtenerCargoEstructuralXlsResponseDTO
    {
        public int anio { get; set; }
        public string descripcionTipoDocumento { get; set; }
        public string nombreProyecto { get; set; }
        public int cantidadCargos { get; set; }
        public string numeroDocumento { get; set; }

        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}
