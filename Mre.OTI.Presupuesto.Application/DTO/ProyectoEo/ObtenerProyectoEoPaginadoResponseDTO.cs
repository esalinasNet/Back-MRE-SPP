using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEo
{
    public class ObtenerProyectoEoPaginadoResponseDTO
    {
        public int idProyecto { get; set; }
        public int idTipoDocumento { get; set; }
        public string descripcionTipoDocumento { get; set; }
        public string descripcionEstado { get; set; }
        public int idEstado { get; set; }
        public string nombreProyecto { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
        public int cantidadUnidad { get; set; }
        public string numeroDocumento { get; set; }
        public DateTime fechaDocumento { get; set; }
        public string documentoRuta { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public int codigoEstado { get; set; }
    }
}
