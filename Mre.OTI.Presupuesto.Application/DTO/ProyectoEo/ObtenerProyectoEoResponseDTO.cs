using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEo
{
    public class ObtenerProyectoEoResponseDTO
    {
        public int idProyecto { get; set; }
        public int idTipoDocumento { get; set; }
        public string descripcionTipoDocumento { get; set; }
        public int idEstado { get; set; }
        public string descripcionEstado { get; set; }
        public string nombreProyecto { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public int cantidadUnidad { get; set; }
        public string numeroDocumento { get; set; }
        public DateTime? fechaDocumento { get; set; }
        public string documentoRuta { get; set; }
        public string usuarioCreacion { get; set; }

        public int codigoEstado { get; set; }


        public DateTime fechaCreacion { get; set; }
        public bool activo { get; set; }
    }
}
